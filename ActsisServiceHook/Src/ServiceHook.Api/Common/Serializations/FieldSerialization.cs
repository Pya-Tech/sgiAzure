using ServiceHook.Api.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServiceHook.Api.Common.Serializations
{
    public class FieldSerialization : JsonConverter<Field>
    {
        public override Field? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                using (var document = JsonDocument.ParseValue(ref reader))
                {
                    var jsonObject = document.RootElement;

                    jsonObject.TryGetProperty("newValue", out JsonElement newValueElement);
                    jsonObject.TryGetProperty("oldValue", out JsonElement oldValueElement);

                    return new Field
                    {
                        NewValue = GetElementAsString(newValueElement),
                        OldValue = GetElementAsString(oldValueElement)
                    };
                }
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                return new Field { NewValue = reader.GetString() ?? string.Empty };
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                return new Field { NewValue = reader.GetInt64().ToString() };
            }


            throw new JsonException("Tipo de valor no soportado para la deserialización.");
        }

        public override void Write(Utf8JsonWriter writer, Field value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }

        private static string? GetElementAsString(JsonElement element)
        {
            return element.ValueKind switch
            {
                JsonValueKind.String => element.GetString(),
                JsonValueKind.Number => element.GetInt64().ToString(),
                _ => null
            };
        }
    }
}
