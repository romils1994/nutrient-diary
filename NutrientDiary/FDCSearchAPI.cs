namespace FDCSearch
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FdcSearchApi
    {
        [JsonProperty("totalHits")]
        public long TotalHits { get; set; }

        [JsonProperty("currentPage")]
        public long CurrentPage { get; set; }

        [JsonProperty("totalPages")]
        public long TotalPages { get; set; }

        [JsonProperty("pageList")]
        public List<long> PageList { get; set; }

        [JsonProperty("foodSearchCriteria")]
        public FoodSearchCriteria FoodSearchCriteria { get; set; }

        [JsonProperty("foods")]
        public List<Food> Foods { get; set; }

        [JsonProperty("aggregations")]
        public Aggregations Aggregations { get; set; }
    }

    public partial class Aggregations
    {
        [JsonProperty("dataType")]
        public DataType DataType { get; set; }

        [JsonProperty("nutrients")]
        public Nutrients Nutrients { get; set; }
    }

    public partial class DataType
    {
        [JsonProperty("Branded")]
        public long Branded { get; set; }

        [JsonProperty("SR Legacy")]
        public long SrLegacy { get; set; }

        [JsonProperty("Survey (FNDDS)")]
        public long SurveyFndds { get; set; }

        [JsonProperty("Foundation")]
        public long Foundation { get; set; }
    }

    public partial class Nutrients
    {
    }

    public partial class FoodSearchCriteria
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("generalSearchInput")]
        public string GeneralSearchInput { get; set; }

        [JsonProperty("pageNumber")]
        public long PageNumber { get; set; }

        [JsonProperty("numberOfResultsPerPage")]
        public long NumberOfResultsPerPage { get; set; }

        [JsonProperty("pageSize")]
        public long PageSize { get; set; }

        [JsonProperty("requireAllWords")]
        public bool RequireAllWords { get; set; }
    }

    public partial class Food
    {
        [JsonProperty("fdcId")]
        public long FdcId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("lowercaseDescription")]
        public string LowercaseDescription { get; set; }

        [JsonProperty("dataType")]
        public string DataType { get; set; }

        [JsonProperty("gtinUpc")]
        public string GtinUpc { get; set; }

        [JsonProperty("publishedDate")]
        public DateTimeOffset PublishedDate { get; set; }

        [JsonProperty("brandOwner")]
        public string BrandOwner { get; set; }

        [JsonProperty("ingredients")]
        public string Ingredients { get; set; }

        [JsonProperty("allHighlightFields")]
        public string AllHighlightFields { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("foodNutrients")]
        public List<FoodNutrient> FoodNutrients { get; set; }
    }

    public partial class FoodNutrient
    {
        [JsonProperty("nutrientId")]
        public long NutrientId { get; set; }

        [JsonProperty("nutrientName")]
        public string NutrientName { get; set; }

        [JsonProperty("nutrientNumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long NutrientNumber { get; set; }

        [JsonProperty("unitName")]
        public string UnitName { get; set; }

        [JsonProperty("derivationCode")]
        public string DerivationCode { get; set; }

        [JsonProperty("derivationDescription")]
        public string DerivationDescription { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public partial class FdcSearchApi
    {
        public static FdcSearchApi FromJson(string json) => JsonConvert.DeserializeObject<FdcSearchApi>(json, FDCSearch.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this FdcSearchApi self) => JsonConvert.SerializeObject(self, FDCSearch.Converter.Settings);
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
