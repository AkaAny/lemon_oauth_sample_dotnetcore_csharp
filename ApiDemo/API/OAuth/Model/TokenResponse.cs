using System;
using System.Text.Json.Serialization;

namespace ApiDemo
{
    public class TokenResponse
    {
        [JsonPropertyName("access_token")] 
        public String AccessToken { get; set; }

        [JsonPropertyName("access_token_expire")]
        public long AccessTokenExpire { get; set; }

        [JsonPropertyName("refresh_token")] 
        public String RefreshToken { get; set; }

        [JsonPropertyName("refresh_token_expire")]
        public String RefreshTokenExpire;

        [JsonPropertyName("staff_id")] 
        public String StaffId;
    }
}