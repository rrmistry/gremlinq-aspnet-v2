namespace gremlinq_aspnet
{
    public abstract class Mammal : Vertex
    {
        public int? Age { get; set; }

        public string? Name { get; set; }
    }
}
