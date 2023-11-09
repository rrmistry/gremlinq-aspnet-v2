using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace gremlinq_aspnet;

/*
// Your class with JSON annotations
public class MyClass
{
    [JsonProperty("custom_name")]
    public string MyProperty { get; set; }

    [JsonIgnore]
    public string IgnoredProperty { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public MyEnum EnumProperty { get; set; }
}

// Enum for demonstration
public enum MyEnum
{
    Value1,
    Value2
}
*/

public static class JsonHelper
{
    // Serialize the object to JToken
    public static JToken SerializeObjectToJToken<T>(T obj)
    {
        // Convert the object to a JSON string
        string jsonString = JsonConvert.SerializeObject(obj);

        // Parse the JSON string into a JToken
        JToken jToken = JToken.Parse(jsonString);

        return jToken;
    }

    // Deserialize the JToken back to object
    public static T DeserializeJTokenToObject<T>(JToken jToken)
    {
        // Convert the JToken to a JSON string
        string jsonString = jToken.ToString();

        // Deserialize the JSON string back to the object
        T obj = JsonConvert.DeserializeObject<T>(jsonString);

        return obj;
    }

    // Serialize the object to JObject
    public static JObject SerializeObjectToJObject<T>(T obj)
    {
        // Convert the object to a JSON string
        string jsonString = JsonConvert.SerializeObject(obj);

        // Parse the JSON string into a JObject
        JObject jObject = JObject.Parse(jsonString);

        return jObject;
    }

    // Deserialize the JObject back to object
    public static T DeserializeJObjectToObject<T>(JObject jObject)
    {
        // Convert the JObject to a JSON string
        string jsonString = jObject.ToString();

        // Deserialize the JSON string back to the object
        T obj = JsonConvert.DeserializeObject<T>(jsonString);

        return obj;
    }
}

// Usage:
// MyClass myObject = new MyClass { MyProperty = "Value", IgnoredProperty = "Ignore", EnumProperty = MyEnum.Value1 };
// JToken token = JsonHelper.SerializeObjectToJToken(myObject);
// MyClass deserializedObject = JsonHelper.DeserializeJTokenToObject<MyClass>(token);
