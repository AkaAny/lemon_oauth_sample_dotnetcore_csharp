using System.Text.Json.Serialization;

namespace ApiDemo
{
    public class PersonInfoResponse
    {
        [JsonPropertyName("STAFFID")]
        public string StaffID { get; set; }
        [JsonPropertyName("STAFFNAME")]
        public string StaffName { get; set; }
        [JsonPropertyName("STAFSTATE")]
        public string StaffState { get; set; }
        [JsonPropertyName("STAFFTYPE")]
        public string StaffType { get; set; }
        [JsonPropertyName("UNITCODE")]
        public string UnitCode { get; set; }
    }
}