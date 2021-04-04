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
            Base64Image = base64image;
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
                QuickType.Objects objectAnnotationResponse = QuickType.Objects.FromJson(response);

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
    }
}
