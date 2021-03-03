using System.Text.Json.Serialization;

namespace ApiDemo
{
    public class StudentInfoResponse
    {
        [JsonPropertyName("STAFFID")]
        public string StaffID { get; set; }
        [JsonPropertyName("STAFFNAME")]
        public string StaffName { get; set; }
        [JsonPropertyName("CLASSID")]
        public string ClassID { get; set; }
        [JsonPropertyName("MAJORCODE")]
        public string MajorCode { get; set; }
        [JsonPropertyName("MAJORNAME")]
        public string MajorName { get; set; }
        [JsonPropertyName("UNITCODE")]
        public string UnitCode { get; set; }
        [JsonPropertyName("UNITNAME")]
        public string UnitName { get; set; }
        [JsonPropertyName("TEACHERID")]
        public string TeacherID { get; set; }
        [JsonPropertyName("TEACHERNAME")]
        public string TeacherName { get; set; }
    }
}