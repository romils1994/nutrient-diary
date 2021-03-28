using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
                                type= "OBJECT_LOCALIZATION",
                                maxResults = 5
                            }
                        }
                    }
                }
            };



            String requestJson = JsonConvert.SerializeObject(visionAPIRequest);

        }
    }
}
