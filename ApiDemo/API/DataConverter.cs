#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiDemo
{
    public class DataConverter<T>:JsonConverter<T> where T:class
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                return JsonSerializer.Deserialize<T>(ref reader);
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, T? stub, JsonSerializerOptions options)
        {
            if (stub == null)
            {
                return;
            }
            writer.WriteStringValue(JsonSerializer.Serialize(stub));
        }
    }
}