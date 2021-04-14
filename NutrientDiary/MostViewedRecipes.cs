namespace Recipes
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MostViewedRecipe
    {
        [JsonProperty("recipe")]
        public Recipe Recipe { get; set; }
    }

    public partial class Recipe
    {
        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("ingredients")]
        public List<string> Ingredients { get; set; }

        [JsonProperty("source_url")]
        public Uri SourceUrl { get; set; }

        [JsonProperty("recipe_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long RecipeId { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("social_rank")]
        public double SocialRank { get; set; }

        [JsonProperty("publisher_url")]
        public Uri PublisherUrl { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class MostViewedRecipe
    {
        public static List<MostViewedRecipe> FromJson(string json) => JsonConvert.DeserializeObject<List<MostViewedRecipe>>(json, Recipes.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<MostViewedRecipe> self) => JsonConvert.SerializeObject(self, Recipes.Converter.Settings);
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
