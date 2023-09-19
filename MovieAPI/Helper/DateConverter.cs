using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Globalization;
using System.Text.Json;
//using Newtonsoft.Json;

namespace MovieAPI.Helper
{
    public class DateConverter : JsonConverter<DateTime>
    {
        private string formatDate = "yyyy-MM-dd hh:mm:ss";

        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
                DateTime.ParseExact(reader.GetString()!,
                    formatDate, CultureInfo.InvariantCulture);

        public override void Write(
            Utf8JsonWriter writer,
            DateTime dateTimeValue,
            JsonSerializerOptions options) =>
                writer.WriteStringValue(dateTimeValue.ToString(
                    formatDate, CultureInfo.InvariantCulture));
    }
}
