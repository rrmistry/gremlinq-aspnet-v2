using ExRam.Gremlinq.Core;
using ExRam.Gremlinq.Core.AspNet;
using ExRam.Gremlinq.Core.Models;
using ExRam.Gremlinq.Core.Transformation;
using ExRam.Gremlinq.Providers.Core.AspNet;
using Gremlin.Net.Driver;
using gremlinq_aspnet;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using ExRam.Gremlinq.Support.NewtonsoftJson;
using Newtonsoft.Json;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGremlinq(
        setup =>
        {
            setup.UseJanusGraph<Vertex, Edge>(
                configuratorTransformation: (configurator, section) =>
                {
                    return configurator.ConfigureServer(
                        s => s
                            .WithHost(host: "localhost")
                            .WithPort(port: 8182)
                            .WithSslEnabled(sslEnabled: false)
                    )
                    // .UseNewtonsoftJson()
                    ;
                }
            )
            // .UseNewtonsoftJson()
            .ConfigureQuerySource(
                source => source
                    .ConfigureEnvironment(
                        source => source.UseModel(
                            GraphModel.FromBaseTypes<Vertex, Edge>()
                        )
                        .UseGraphSon3()
                        .UseNewtonsoftJson()
                        // .RegisterNativeType<Vertex, JToken>(
                        //     serializer: (v, e, t) => JsonHelper.SerializeObjectToJToken<Vertex>(obj: v),
                        //     deserializer: (j, e, t) => JsonHelper.DeserializeJTokenToObject<Vertex>(j)
                        // )
                        // .RegisterNativeType<Edge, JToken>(
                        //     serializer: (v, e, t) => JsonHelper.SerializeObjectToJToken<Edge>(obj: v),
                        //     deserializer: (j, e, t) => JsonHelper.DeserializeJTokenToObject<Edge>(j)
                        // )
                        // .UseNewtonsoftJson()
                        // .ConfigureSerializer(
                        //     serializerTransformation: transformer => transformer
                        //     // .Add(new MyNewtonsoftJsonSerializerConverterFactory())
                        //     // .Add(ConverterFactory
                        //     //     .Create<byte[], JToken?>((bytes, _, _) => JToken.ReadFrom(
                        //     //         new JsonTextReader(new StreamReader(new MemoryStream(bytes)))
                        //     //         {
                        //     //             DateParseHandling = DateParseHandling.None
                        //     //         })))
                        //     // .Add(new VertexPropertyPropertiesConverterFactory())
                        //     /*
                        //     .Add(
                        //         ConverterFactory.Create<Vertex, JToken>(
                        //             (o, e, t) => JsonHelper.SerializeObjectToJToken<Vertex>(obj: o)
                        //         )
                        //     )
                        //     .Add(
                        //         ConverterFactory.Create<Edge, JToken>(
                        //             (o, e, t) => JsonHelper.SerializeObjectToJToken<Edge>(obj: o)
                        //         )
                        //     )
                        //     .Add(
                        //         ConverterFactory.Create<Vertex, JObject>(
                        //             (o, e, t) => JsonHelper.SerializeObjectToJObject<Vertex>(obj: o)
                        //         )
                        //     )
                        //     .Add(
                        //         ConverterFactory.Create<Edge, JObject>(
                        //             (o, e, t) => JsonHelper.SerializeObjectToJObject<Edge>(obj: o)
                        //         )
                        //     )
                        //     */
                        // )
                        // .ConfigureDeserializer(
                        //     deserializerTransformation: transformer => transformer
                        //     // .Add(new MyNewtonsoftJsonSerializerConverterFactory())
                        //     // .Add(ConverterFactory
                        //     //     .Create<byte[], JToken?>((bytes, _, _) => JToken.ReadFrom(
                        //     //         new JsonTextReader(new StreamReader(new MemoryStream(bytes)))
                        //     //         {
                        //     //             DateParseHandling = DateParseHandling.None
                        //     //         })))
                        //     // .Add(new VertexPropertyPropertiesConverterFactory())
                        //     /*
                        //     .Add(
                        //         ConverterFactory.Create<JToken, Vertex>(
                        //             (j, e, t) => JsonHelper.DeserializeJTokenToObject<Vertex>(j)
                        //         )
                        //     )
                        //     .Add(
                        //         ConverterFactory.Create<JToken, Edge>(
                        //             (j, e, t) => JsonHelper.DeserializeJTokenToObject<Edge>(j)
                        //         )
                        //     )
                        //     .Add(
                        //         ConverterFactory.Create<JObject, Vertex>(
                        //             (j, e, t) => JsonHelper.DeserializeJObjectToObject<Vertex>(j)
                        //         )
                        //     )
                        //     .Add(
                        //         ConverterFactory.Create<JObject, Edge>(
                        //             (j, e, t) => JsonHelper.DeserializeJObjectToObject<Edge>(j)
                        //         )
                        //     )
                        //     */
                        // )
                        // .UseNewtonsoftJson()
                    )
            );
        }
    )
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();

app.Run();
