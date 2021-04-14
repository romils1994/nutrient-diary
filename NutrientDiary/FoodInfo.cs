using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrientDiary
{
    public partial class FoodInfo
    {
        public long FdcId { get; set; }
        public string Description { get; set; }
        public List<FoodNutrient> FoodNutrients { get; set; }
        public string BrandedFoodCategory { get; set; }
        public long ServingSize { get; set; }
        public string ServingSizeUnit { get; set; }
        public int PortionSize { get; set; }
        public string FoodCategory { get; set; }
    }

    public partial class FoodNutrient
    {
        public string Name { get; set; }
        public string UnitName { get; set; }
        public double Amount { get; set; }
    }
}
