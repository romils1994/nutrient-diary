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

        public void OnPost(string base64)
        {
            Base64Image = base64;
            String requestJson = "{​\"requests\":[{​\"features\":[{​\"maxResults\":5,\"type\":\"OBJECT_LOCALIZATION\"}​],\"image\":{​\"content\":\"" + Base64Image + "\"}​}​]}​";

        }
    }
}
