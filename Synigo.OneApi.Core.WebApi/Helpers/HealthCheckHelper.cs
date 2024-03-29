﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Synigo.OneApi.Core.WebApi.Helpers
{
    internal class HealthCheckHelper
    {
        internal static Task WriteResponse(HttpContext context, HealthReport healthReport)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions { Indented = true };

            using var memoryStream = new MemoryStream();
            using (var jsonWriter = new Utf8JsonWriter(memoryStream, options))
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WriteString("status", healthReport.Status.ToString());
                jsonWriter.WriteStartObject("results");

                foreach (var healthReportEntry in healthReport.Entries)
                {
                    jsonWriter.WriteStartObject(healthReportEntry.Key);
                    jsonWriter.WriteString("status", healthReportEntry.Value.Status.ToString());
                    jsonWriter.WriteString("description", healthReportEntry.Value.Description);

                    jsonWriter.WriteStartArray("tags");
                    foreach (var item in healthReportEntry.Value.Tags)
                    {
                        jsonWriter.WriteStringValue(item);
                    }
                    jsonWriter.WriteEndArray();

                    jsonWriter.WriteStartObject("data");
                    foreach (var item in healthReportEntry.Value.Data)
                    {
                        jsonWriter.WritePropertyName(item.Key);

                        JsonSerializer.Serialize(jsonWriter, item.Value,
                            item.Value?.GetType() ?? typeof(object));
                    }
                    jsonWriter.WriteEndObject();

                    jsonWriter.WriteEndObject();
                }

                jsonWriter.WriteEndObject();
                jsonWriter.WriteEndObject();
            }

            return context.Response.WriteAsync(
                Encoding.UTF8.GetString(memoryStream.ToArray()));
        }
    }
}
