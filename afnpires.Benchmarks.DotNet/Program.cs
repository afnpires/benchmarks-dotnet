using afnpires.Benchmarks.DotNet.StaticLamdba;

namespace afnpires.Benchmarks.DotNet
{
    using afnpires.Benchmarks.DotNet.Collections;
    using afnpires.Benchmarks.DotNet.GetHashCodeImplementation;
    using BenchmarkDotNet.Running;
    using BisectCollection;
    using Serialization;

    public class Program
    {
        public static void Main()
        {
            //var summary = BenchmarkRunner.Run<GetHashCodeTest>();
            // var summary = BenchmarkRunner.Run<ListTest>();
            // var summary = BenchmarkRunner.Run<ByteArrayJsonSerializationTests>();
            var summary = BenchmarkRunner.Run<BisectCollectionTest>();
        }
    }
}
