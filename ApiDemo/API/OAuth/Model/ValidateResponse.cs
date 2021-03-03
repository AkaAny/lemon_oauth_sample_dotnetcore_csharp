using System;
using System.Text.Json.Serialization;

namespace ApiDemo
{
    public class ValidateResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        
        [JsonPropertyName("access_token_expire")]
        public long AccessTokenExpire { get; set; }
        
        [JsonPropertyName("staff_id")]
        public string StaffID { get; set; }
    }
}