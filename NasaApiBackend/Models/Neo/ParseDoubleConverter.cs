using System.Text.Json;
using System.Text.Json.Serialization;

namespace NasaApiBackend.Models.Neo
{
    public class ParseDoubleConverter : JsonConverter<double>
    {
        public override bool CanConvert(Type t) => t == typeof(double);

        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            try
            {
                return Convert.ToDouble(value, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch(Exception ex)
            {
                throw new Exception("Cannot unmarshal type DateTime");
            }
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToString(), options);
            return;
        }
    }
}
