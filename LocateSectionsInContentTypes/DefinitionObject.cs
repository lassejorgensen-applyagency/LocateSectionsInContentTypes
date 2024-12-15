using Newtonsoft.Json;

namespace Types
{
    public class DataTypesJsonObject
    {
        public string? DataTypeKeyAttribute { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? DataTypeInfoName { get; set; }
        public List<string> DataTypeValues { get; set; } = new List<string>();
        public List<string> DataTypeSections { get; set; } = new List<string>();
    }
    //public class ThemeStructure
    //{
    //    public string? ContentTypeName { get; set; }
    //    public string? DefinitionKey { get; set; }
    //    public List<string> Values { get; set; } = new List<string>();
    //    public List<string> Sections { get; set; } = new List<string>();

    //}
    //public class JsonObject
    //{
    //    public string? DefinitionKey { get; set; }
    //    public List<string>? Values { get; set; }
    //}



}
