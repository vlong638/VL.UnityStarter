using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VL.Gaming.Scripts.Gaming.GameSystem;

namespace VL.Gaming.Scripts.Gaming.Utils
{
    public class Vector3Converter : JsonConverter<Vector3>
    {
        public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
        {
            // 序列化为 JSON 对象
            JObject obj = new JObject
        {
            { "x", value.x },
            { "y", value.y },
            { "z", value.z }
        };
            obj.WriteTo(writer);
        }

        public override Vector3 ReadJson(JsonReader reader, System.Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // 从 JSON 对象反序列化
            JObject obj = JObject.Load(reader);
            return new Vector3(
                (float)obj["x"],
                (float)obj["y"],
                (float)obj["z"]
            );
        }
    }
    public static class VLStatics
    {
        public static JsonSerializerSettings JsonSettings => new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
        {
            new Vector3Converter(),
        },
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
    }
}
