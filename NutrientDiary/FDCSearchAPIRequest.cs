using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrientDiary
{
    public class FDCSearchAPIRequest
    {
        public string query { get; set; }
        public List<string> dataType { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public string sortBy { get; set; }
        public string sortOrder { get; set; }
        public string brandOwner { get; set; }
    }
}
