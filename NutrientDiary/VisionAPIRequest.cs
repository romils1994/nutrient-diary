using System.Collections.Generic;


namespace NutrientDiary
{
    public class VisionAPIRequest
    {
        public List<Requests> Requests { get; set; }
    }
    public class Requests
    {
        public Image Image { get; set; }
        public List<Features> Features { get; set; }
    }

    public class Image
    {
        public string Content { get; set; }
    }
    public class Features
    {
        public string Type { get; set; }
        public int MaxResults { get; set; }
    }
}