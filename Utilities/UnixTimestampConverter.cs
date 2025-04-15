using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinanceBackend.NewFolder
{
    public class UnixTimestampConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            long seconds = reader.GetInt64();
            return DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            long unixTime = ((DateTimeOffset)value).ToUnixTimeSeconds();
            writer.WriteNumberValue(unixTime);

        }
    }
}
