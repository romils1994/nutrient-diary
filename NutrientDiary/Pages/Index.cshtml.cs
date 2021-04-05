using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        public List<string> Objects = new List<string>();

        public void OnPost(string base64image)
        {
            //adding try catch
            try 
            {
                Base64Image = base64image;

                var imageParts = base64image.Split(',').ToList<string>();
                //to check if imageparts is null or empty 
                if (imageParts == null || !imageParts.Any())
                {
                    throw new ArgumentException(" imageParts is NULL", nameof(imageParts));
                }

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
                                type = "OBJECT_LOCALIZATION",
                                maxResults = 5
                            }
                        }
                    }
                }
                };

                String requestJson = JsonConvert.SerializeObject(visionAPIRequest);
                String apiKey = System.IO.File.ReadAllText("VisionAPIKey.txt");
                String url = "https://vision.googleapis.com/v1/images:annotate?key=" + apiKey;
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Content-Type", "application/json");
                    String response = Encoding.ASCII.GetString(webClient.UploadData(new Uri(url), "POST", Encoding.UTF8.GetBytes(requestJson)));
                    //Todo null check for response
                    if (response == null)
                    {
                        throw new ArgumentException("Response is NULL", nameof(response));

                    }
                    QuickType.Objects objectAnnotationResponse = QuickType.Objects.FromJson(response);

                    //null check for objectAnnotationResponse
                    if (objectAnnotationResponse == null )
                    {
                        throw new ArgumentException("objectAnnotationResponse is NULL", nameof(objectAnnotationResponse));

                    }

                    foreach (QuickType.Response responses in objectAnnotationResponse.Responses)
                    {
                        foreach (QuickType.LocalizedObjectAnnotation localizedObject in responses.LocalizedObjectAnnotations)
                        {
                            if (!Objects.Contains(localizedObject.Name))
                            {
                                Objects.Add(localizedObject.Name);
                            }
                        }
                    }
                }
            }
         
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
