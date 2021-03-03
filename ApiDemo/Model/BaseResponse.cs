#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiDemo
{
    public class BaseResponse<T> where T:class
    {
        [JsonPropertyName("cache")]
        public bool Cache { get; set; }

        [JsonPropertyName("error")]
        public int Error { get; set; }

        [JsonPropertyName("msg")]
        public string Msg { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }

        public bool IsSuccess()
        {
            return Error == 0;
        }
    }

    public class StringResponse:BaseResponse<string>
    {
        public static StringResponse Create(int error, string msg)
        {
            return new StringResponse()
            {
                Error = error,
                Msg = msg,
                Data = null,
            };
        }
    }
}