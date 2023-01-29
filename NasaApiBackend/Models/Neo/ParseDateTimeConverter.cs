using System.Text.Json;
using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.Neo
{
    public class ParseDateTimeConverter : JsonConverter<DateTime>
    {
        public override bool CanConvert(Type t) => t == typeof(DateTime);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            DateTime dt;
            if (DateTime.TryParse(value, out dt))
            {
                return dt;
            }
            throw new Exception("Cannot unmarshal type DateTime");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToString(), options);
            return;
        }
    }
}
