using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrientDiary
{
    public class FDCFoodInfoAPIRequest
    {
        public List<long> fdcIds { get; set; }
        public string format { get; set; }
        public List<int> nutrients { get; set; }
    }


}
