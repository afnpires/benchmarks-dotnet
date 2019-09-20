namespace afnpires.Benchmarks.DotNet.Serialization
{
    using System.IO;
    using System.Text;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnostics.Windows.Configs;
    using Newtonsoft.Json;

    [MemoryDiagnoser]
    [InliningDiagnoser]
    [MinColumn]
    [MaxColumn]
    [MarkdownExporter]
    [RPlotExporter]
    public class ByteArrayJsonSerializationTests
    {
        public const int Iterations = 1000;

        private static readonly AnObject testData = new AnObject
        {
            Number = 1,
            Text = "cenas",
            Object = new OtherObject
            {
                Number = 1,
                Text = "cenas",
            }
        };

        public static readonly byte[] rawTestData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(testData));

        [Benchmark]
        public void ToStringThenJson()
        {
            AnObject holder;
            for (var i = 0; i < Iterations; i++)
            {
                var stringContent = Encoding.UTF8.GetString(rawTestData);
                holder = JsonConvert.DeserializeObject<AnObject>(stringContent);
            }
        }

        [Benchmark]
        public void InlineMemoryStreamReader()
        {
            AnObject holder;
            for (var i = 0; i < Iterations; i++)
            {
                using (var sr = new StreamReader(new MemoryStream(rawTestData)))
                {
                    holder = JsonConvert.DeserializeObject<AnObject>(sr.ReadToEnd());
                }
            }
        }
        
        [Benchmark]
        public void MemoryStreamReader()
        {
            AnObject holder;
            for (var i = 0; i < Iterations; i++)
            {
                using (var stream = new MemoryStream(rawTestData))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                    holder = JsonSerializer.Create().Deserialize(reader, typeof(AnObject)) as AnObject;
            }
        }

        [Benchmark]
        public void MemoryStreamJsonReader()
        {
            AnObject holder;
            var serializer = new JsonSerializer();
            for (var i = 0; i < Iterations; i++)
            {
                using (var memoryStream = new MemoryStream(rawTestData))
                using (var streamReader = new StreamReader(memoryStream))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    holder = serializer.Deserialize<AnObject>(jsonReader);
                }
            }
        }
        
        public class AnObject
        {
            public string Text { get; set; }

            public int Number { get; set; }

            public OtherObject Object { get; set; }
        }

        public class OtherObject
        {
            public string Text { get; set; }

            public int Number { get; set; }
        }
    }
}