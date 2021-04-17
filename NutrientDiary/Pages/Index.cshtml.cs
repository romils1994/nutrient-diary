using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NutrientDiary.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Base64Image { get; set; }

        public string Error;

        public bool isPostBack = false;

        public List<FoodInfo> FoodDetails = new List<FoodInfo>(); 

        private const string FEATURE_TYPE = "OBJECT_LOCALIZATION";

        [BindProperty(SupportsGet = true)]
        public string query { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (!String.IsNullOrEmpty(query) && !String.IsNullOrWhiteSpace(query))
            {
                List<string> queryList = new List<string>();
                queryList.Add(query);
                List<long> fdcIds = this.detectFoodItems(queryList);
                if (fdcIds.Any())
                {
                    FoodDetails = this.getFoodInfo(fdcIds);
                }

                if (FoodDetails.Any())
                {
                    return new JsonResult(FoodDetails);
                }
                else
                {
                    Error noDataResult = new Error()
                    {
                        ErrorCode = 400,
                        ErrorMessage = "No search result Found"
                    };
                    return new JsonResult(noDataResult);
                }
            }

            return Page();
        }

        public void OnPost(string base64image)
        {
            Base64Image = base64image;
            isPostBack = true;
            List<string> objects = this.detectObjects(base64image);
            if (objects.Any())
            {
                List<long> fdcIds = this.detectFoodItems(objects);
                if (fdcIds.Any())
                {
                    FoodDetails = this.getFoodInfo(fdcIds);
                }
            }
        }

        private List<string> detectObjects(string base64image)
        {
            var imageParts = base64image.Split(',').ToList<string>();

            VisionAPIRequest visionAPIRequest = new VisionAPIRequest()
            {
                requests = new List<requests>()
                {
                    new requests()
                    {
                        image = new image()
                        {
                            content = imageParts[1]
                        },
                        features = new List<features>()
                        {
                            new features()
                            {
                                type = FEATURE_TYPE,
                                maxResults = 5
                            }
                        }
                    }
                }
            };

            String visionAPIReqStr = JsonConvert.SerializeObject(visionAPIRequest);
            String apiKey = System.IO.File.ReadAllText("VisionAPIKey.txt");
            String domain = "vision.googleapis.com";
            String endpoint = "v1/images:annotate";
            String visionAPIRespStr = this.callPostAPI(visionAPIReqStr,domain,endpoint,apiKey,"key");
            JSchema visionAPISchema = JSchema.Parse(System.IO.File.ReadAllText("VisionAPISchema.json"));
            JObject visionAPIRespObj = JObject.Parse(visionAPIRespStr);
            List<string> objects = new List<string>();
            IList<string> validationEvents = new List<string>();
            if (visionAPIRespObj.IsValid(visionAPISchema, out validationEvents))
            {
                if (!String.IsNullOrEmpty(visionAPIRespStr))
                {
                    VisionAPI.Objects objectAnnotationResponse = VisionAPI.Objects.FromJson(visionAPIRespStr);
                    foreach (VisionAPI.Response responses in objectAnnotationResponse.Responses)
                    {
                        foreach (VisionAPI.LocalizedObjectAnnotation localizedObject in responses.LocalizedObjectAnnotations)
                        {
                            if (!objects.Contains(localizedObject.Name))
                            {
                                objects.Add(localizedObject.Name);
                            }
                        }
                    }
                }
            }
            return objects;
        }

        private List<long> detectFoodItems(List<string> objects)
        {
            String apiKey = System.IO.File.ReadAllText("FDCAPIKey.txt");
            String domain = "api.nal.usda.gov";
            String endpoint = "fdc/v1/foods/search";
            List<long> fdcIds = new List<long>();
            foreach (string obj in objects) {
                FDCSearchAPIRequest fDCSearchAPIRequest = new FDCSearchAPIRequest()
                {
                    query = obj,
                    pageSize = 1,
                    pageNumber = 1
                };
                String fdcSearchReqStr = JsonConvert.SerializeObject(fDCSearchAPIRequest);
                String fdcSearchRespStr = this.callPostAPI(fdcSearchReqStr, domain, endpoint, apiKey, "api_key");
                FDCSearch.FdcSearchApi fdcSearchResponse = FDCSearch.FdcSearchApi.FromJson(fdcSearchRespStr);
                foreach (FDCSearch.Food foods in fdcSearchResponse.Foods)
                {
                    fdcIds.Add(foods.FdcId);
                }
            }

            return fdcIds;
        }

        private List<FoodInfo> getFoodInfo(List<long> fdcIds)
        {
            String apiKey = System.IO.File.ReadAllText("FDCAPIKey.txt");
            String domain = "api.nal.usda.gov";
            String endpoint = "fdc/v1/foods";
            FDCFoodInfoAPIRequest fDCFoodInfoAPIRequest = new FDCFoodInfoAPIRequest()
            {
                fdcIds = fdcIds
            };
            String fdcFoodInfoReqStr = JsonConvert.SerializeObject(fDCFoodInfoAPIRequest);
            String fdcFoodInfoRespStr = this.callPostAPI(fdcFoodInfoReqStr, domain, endpoint, apiKey, "api_key");
            List<FoodInfo> foodDict = new List<FoodInfo>();
            List<FDCFoodInfo.FdcFoodInfoApi> fdcFoodInfoResponse = FDCFoodInfo.FdcFoodInfoApi.FromJson(fdcFoodInfoRespStr);
            foreach (FDCFoodInfo.FdcFoodInfoApi fdcFoodInfo in fdcFoodInfoResponse)
            {
                List<FoodNutrient> foodNutrients = new List<FoodNutrient>();
                foreach (FDCFoodInfo.FoodNutrient foodNutrient in fdcFoodInfo.FoodNutrients)
                {
                    foodNutrients.Add(new FoodNutrient()
                    {
                        Name = foodNutrient.Nutrient.Name,
                        Amount = foodNutrient.Amount,
                        UnitName = foodNutrient.Nutrient.UnitName
                    });
                }

                foodDict.Add(new FoodInfo()
                {
                    FdcId = fdcFoodInfo.FdcId,
                    Description = fdcFoodInfo.Description,
                    BrandedFoodCategory = fdcFoodInfo.BrandedFoodCategory,
                    ServingSizeUnit = fdcFoodInfo.ServingSizeUnit,
                    FoodNutrients = foodNutrients,
                    PortionSize = 100
                });
            }
            
            return foodDict;
        }

        private string callPostAPI (string requestJson, string domain, string endpoint = null, string apiKey = null, string apiKeyParam = null, string protocol = "https")
        {
            String url = protocol + "://" + domain + "/" + endpoint + "?" + apiKeyParam + "=" + apiKey;
            String response = null;
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", "application/json");
                try
                {
                    response = Encoding.ASCII.GetString(webClient.UploadData(new Uri(url), "POST", Encoding.UTF8.GetBytes(requestJson)));
                }
                catch (Exception ex)
                {
                    Error = "Something went wrong! Could not reach the API Servers";
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace.ToString());
                }
            }

            return response;
        }
    }
}
