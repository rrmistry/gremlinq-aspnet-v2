using System;

namespace gremlinq_aspnet
{
    public abstract class Mammal : Vertex
    {
        public int? Age {
            get;
            set;
        }

        public string? Name
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int RandomInteger { get; set; } = new Random().Next();

        [Newtonsoft.Json.JsonProperty("custom_name")]
        public int different_name { get; set; } = new Random().Next();
    }
}
