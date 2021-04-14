namespace FDCFoodInfo
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FdcFoodInfoApi
    {
        [JsonProperty("dataType", NullValueHandling = NullValueHandling.Ignore)]
        public string DataType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fdcId")]
        public long FdcId { get; set; }

        [JsonProperty("foodNutrients", NullValueHandling = NullValueHandling.Ignore)]
        public List<FoodNutrient> FoodNutrients { get; set; }

        [JsonProperty("publicationDate")]
        public string PublicationDate { get; set; }

        [JsonProperty("brandOwner", NullValueHandling = NullValueHandling.Ignore)]
        public string BrandOwner { get; set; }

        [JsonProperty("gtinUpc", NullValueHandling = NullValueHandling.Ignore)]
        public string GtinUpc { get; set; }

        [JsonProperty("ndbNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? NdbNumber { get; set; }

        [JsonProperty("foodCode", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FoodCode { get; set; }

        [JsonProperty("availableDate", NullValueHandling = NullValueHandling.Ignore)]
        public string AvailableDate { get; set; }

        [JsonProperty("dataSource", NullValueHandling = NullValueHandling.Ignore)]
        public string DataSource { get; set; }

        [JsonProperty("foodClass", NullValueHandling = NullValueHandling.Ignore)]
        public string FoodClass { get; set; }

        [JsonProperty("householdServingFullText", NullValueHandling = NullValueHandling.Ignore)]
        public string HouseholdServingFullText { get; set; }

        [JsonProperty("ingredients", NullValueHandling = NullValueHandling.Ignore)]
        public string Ingredients { get; set; }

        [JsonProperty("modifiedDate", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifiedDate { get; set; }

        [JsonProperty("servingSize", NullValueHandling = NullValueHandling.Ignore)]
        public long? ServingSize { get; set; }

        [JsonProperty("servingSizeUnit", NullValueHandling = NullValueHandling.Ignore)]
        public string ServingSizeUnit { get; set; }

        [JsonProperty("brandedFoodCategory", NullValueHandling = NullValueHandling.Ignore)]
        public string BrandedFoodCategory { get; set; }

        [JsonProperty("foodUpdateLog", NullValueHandling = NullValueHandling.Ignore)]
        public List<FoodUpdateLog> FoodUpdateLog { get; set; }

        [JsonProperty("labelNutrients", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, LabelNutrient> LabelNutrients { get; set; }

        [JsonProperty("footNote", NullValueHandling = NullValueHandling.Ignore)]
        public string FootNote { get; set; }

        [JsonProperty("isHistoricalReference", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsHistoricalReference { get; set; }

        [JsonProperty("scientificName", NullValueHandling = NullValueHandling.Ignore)]
        public string ScientificName { get; set; }

        [JsonProperty("foodCategory", NullValueHandling = NullValueHandling.Ignore)]
        public Food FoodCategory { get; set; }

        [JsonProperty("foodComponents", NullValueHandling = NullValueHandling.Ignore)]
        public List<FoodComponent> FoodComponents { get; set; }

        [JsonProperty("foodPortions", NullValueHandling = NullValueHandling.Ignore)]
        public List<FoodPortion> FoodPortions { get; set; }

        [JsonProperty("inputFoods", NullValueHandling = NullValueHandling.Ignore)]
        public List<InputFoodElement> InputFoods { get; set; }

        [JsonProperty("nutrientConversionFactors", NullValueHandling = NullValueHandling.Ignore)]
        public List<NutrientConversionFactor> NutrientConversionFactors { get; set; }

        [JsonProperty("datatype", NullValueHandling = NullValueHandling.Ignore)]
        public string Datatype { get; set; }

        [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
        public string EndDate { get; set; }

        [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
        public string StartDate { get; set; }

        [JsonProperty("foodAttributes", NullValueHandling = NullValueHandling.Ignore)]
        public List<FoodAttribute> FoodAttributes { get; set; }

        [JsonProperty("wweiaFoodCategory", NullValueHandling = NullValueHandling.Ignore)]
        public WweiaFoodCategory WweiaFoodCategory { get; set; }
    }

    public partial class FoodAttribute
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("sequenceNumber")]
        public long SequenceNumber { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("FoodAttributeType")]
        public FoodAttributeType FoodAttributeType { get; set; }
    }

    public partial class FoodAttributeType
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class Food
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("foodNutrientSource", NullValueHandling = NullValueHandling.Ignore)]
        public Food FoodNutrientSource { get; set; }
    }

    public partial class FoodComponent
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dataPoints")]
        public long DataPoints { get; set; }

        [JsonProperty("gramWeight")]
        public double GramWeight { get; set; }

        [JsonProperty("isRefuse")]
        public bool IsRefuse { get; set; }

        [JsonProperty("minYearAcquired")]
        public long MinYearAcquired { get; set; }

        [JsonProperty("percentWeight")]
        public double PercentWeight { get; set; }
    }

    public partial class FoodNutrient
    {
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public long? Number { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("unitName", NullValueHandling = NullValueHandling.Ignore)]
        public string UnitName { get; set; }

        [JsonProperty("derivationCode", NullValueHandling = NullValueHandling.Ignore)]
        public string DerivationCode { get; set; }

        [JsonProperty("derivationDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string DerivationDescription { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("dataPoints", NullValueHandling = NullValueHandling.Ignore)]
        public long? DataPoints { get; set; }

        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public double? Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public double? Max { get; set; }

        [JsonProperty("median", NullValueHandling = NullValueHandling.Ignore)]
        public double? Median { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("nutrient", NullValueHandling = NullValueHandling.Ignore)]
        public Nutrient Nutrient { get; set; }

        [JsonProperty("foodNutrientDerivation", NullValueHandling = NullValueHandling.Ignore)]
        public Food FoodNutrientDerivation { get; set; }

        [JsonProperty("nutrientAnalysisDetails", NullValueHandling = NullValueHandling.Ignore)]
        public NutrientAnalysisDetails NutrientAnalysisDetails { get; set; }
    }

    public partial class Nutrient
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("number")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("unitName")]
        public string UnitName { get; set; }
    }

    public partial class NutrientAnalysisDetails
    {
        [JsonProperty("subSampleId")]
        public long SubSampleId { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("nutrientId")]
        public long NutrientId { get; set; }

        [JsonProperty("labMethodDescription")]
        public string LabMethodDescription { get; set; }

        [JsonProperty("labMethodOriginalDescription")]
        public string LabMethodOriginalDescription { get; set; }

        [JsonProperty("labMethodLink")]
        public Uri LabMethodLink { get; set; }

        [JsonProperty("labMethodTechnique")]
        public string LabMethodTechnique { get; set; }

        [JsonProperty("nutrientAcquisitionDetails")]
        public List<NutrientAcquisitionDetail> NutrientAcquisitionDetails { get; set; }
    }

    public partial class NutrientAcquisitionDetail
    {
        [JsonProperty("sampleUnitId")]
        public long SampleUnitId { get; set; }

        [JsonProperty("purchaseDate")]
        public string PurchaseDate { get; set; }

        [JsonProperty("storeCity")]
        public string StoreCity { get; set; }

        [JsonProperty("storeState")]
        public string StoreState { get; set; }
    }

    public partial class FoodPortion
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("dataPoints")]
        public long DataPoints { get; set; }

        [JsonProperty("gramWeight")]
        public long GramWeight { get; set; }

        [JsonProperty("minYearAcquired")]
        public long MinYearAcquired { get; set; }

        [JsonProperty("modifier")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Modifier { get; set; }

        [JsonProperty("portionDescription")]
        public string PortionDescription { get; set; }

        [JsonProperty("sequenceNumber")]
        public long SequenceNumber { get; set; }

        [JsonProperty("measureUnit")]
        public MeasureUnit MeasureUnit { get; set; }
    }

    public partial class MeasureUnit
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class FoodUpdateLog
    {
        [JsonProperty("fdcId")]
        public long FdcId { get; set; }

        [JsonProperty("availableDate")]
        public string AvailableDate { get; set; }

        [JsonProperty("brandOwner")]
        public string BrandOwner { get; set; }

        [JsonProperty("dataSource")]
        public string DataSource { get; set; }

        [JsonProperty("dataType")]
        public string DataType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("foodClass")]
        public string FoodClass { get; set; }

        [JsonProperty("gtinUpc")]
        public string GtinUpc { get; set; }

        [JsonProperty("householdServingFullText")]
        public string HouseholdServingFullText { get; set; }

        [JsonProperty("ingredients")]
        public string Ingredients { get; set; }

        [JsonProperty("modifiedDate")]
        public string ModifiedDate { get; set; }

        [JsonProperty("publicationDate")]
        public string PublicationDate { get; set; }

        [JsonProperty("servingSize")]
        public long ServingSize { get; set; }

        [JsonProperty("servingSizeUnit")]
        public string ServingSizeUnit { get; set; }

        [JsonProperty("brandedFoodCategory")]
        public string BrandedFoodCategory { get; set; }

        [JsonProperty("changes")]
        public string Changes { get; set; }

        [JsonProperty("foodAttributes")]
        public List<FoodAttribute> FoodAttributes { get; set; }
    }

    public partial class InputFoodElement
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("foodDescription")]
        public string FoodDescription { get; set; }

        [JsonProperty("inputFood", NullValueHandling = NullValueHandling.Ignore)]
        public InputFoodInputFood InputFood { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? Amount { get; set; }

        [JsonProperty("ingredientCode", NullValueHandling = NullValueHandling.Ignore)]
        public long? IngredientCode { get; set; }

        [JsonProperty("ingredientDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string IngredientDescription { get; set; }

        [JsonProperty("ingredientWeight", NullValueHandling = NullValueHandling.Ignore)]
        public double? IngredientWeight { get; set; }

        [JsonProperty("portionCode", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? PortionCode { get; set; }

        [JsonProperty("portionDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string PortionDescription { get; set; }

        [JsonProperty("sequenceNumber", NullValueHandling = NullValueHandling.Ignore)]
        public long? SequenceNumber { get; set; }

        [JsonProperty("surveyFlag", NullValueHandling = NullValueHandling.Ignore)]
        public long? SurveyFlag { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("retentionFactor", NullValueHandling = NullValueHandling.Ignore)]
        public RetentionFactor RetentionFactor { get; set; }
    }

    public partial class InputFoodInputFood
    {
        [JsonProperty("fdcId")]
        public long FdcId { get; set; }

        [JsonProperty("datatype")]
        public string Datatype { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("foodClass")]
        public string FoodClass { get; set; }

        [JsonProperty("publicationDate")]
        public string PublicationDate { get; set; }

        [JsonProperty("foodAttributes")]
        public List<Food> FoodAttributes { get; set; }
    }

    public partial class RetentionFactor
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class LabelNutrient
    {
        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public partial class NutrientConversionFactor
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public partial class WweiaFoodCategory
    {
        [JsonProperty("wweiaFoodCategoryCode")]
        public long WweiaFoodCategoryCode { get; set; }

        [JsonProperty("wweiaFoodCategoryDescription")]
        public string WweiaFoodCategoryDescription { get; set; }
    }

    public partial class FdcFoodInfoApi
    {
        public static List<FdcFoodInfoApi> FromJson(string json) => JsonConvert.DeserializeObject<List<FdcFoodInfoApi>>(json, FDCFoodInfo.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<FdcFoodInfoApi> self) => JsonConvert.SerializeObject(self, FDCFoodInfo.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
