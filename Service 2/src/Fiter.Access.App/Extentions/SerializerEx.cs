using System;
using System.Text.Json;

namespace Application.Extentions
{
    public static class SerializerEx
    {
        public static byte[] ToUtf8Bytes(this object value, JsonSerializerOptions options = null)
        {
            if (value == null) { return default; }

            try { return options != null ? JsonSerializer.SerializeToUtf8Bytes(value, options) : JsonSerializer.SerializeToUtf8Bytes(value); }
            catch { return default; }
        }

        public static string ToJson(this object value, JsonSerializerOptions options = null)
        {
            if (value == null) { return String.Empty; }

            try { return options != null ? JsonSerializer.Serialize(value, options) : JsonSerializer.Serialize(value); }
            catch { return String.Empty; }
        }

        public static T To<T>(this string str, JsonSerializerOptions options = null)
        {
            if (string.IsNullOrEmpty(str)) { return default(T); }

            try {  return options != null ? JsonSerializer.Deserialize<T>(str, options) : JsonSerializer.Deserialize<T>(str); }
            catch (Exception) { return default(T); }
        }

    }
 }