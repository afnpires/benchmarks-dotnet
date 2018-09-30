namespace afnpires.Benchmarks.DotNet.GetHashCodeImplementation
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnostics.Windows.Configs;

    [MemoryDiagnoser]
    [InliningDiagnoser]
    [MinColumn]
    [MaxColumn]
    [MarkdownExporter]
    [RPlotExporter]
    public class GetHashCodeTest
    {
        private const int Iterations = 1000;

        [Benchmark]
        public static void TupleGetHashCode()
        {
            var sut = new PocoWithTupleGetHashCode
            {
                Name = "Test",
                Value = 10
            };

            for (int i = 0; i < Iterations; i++)
            {
                sut.GetHashCode();
            }
        }

        [Benchmark]
        public static void UncheckedGetHashCode()
        {
            var sut = new PocoWithUncheckedGetHashCode
            {
                Name = "Test",
                Value = 10
            };

            for (int i = 0; i < Iterations; i++)
            {
                sut.GetHashCode();
            }
        }

        [Benchmark]
        public static void HashCodeCombineGetHashCode()
        {
            var sut = new PocoWithHashCodeCombine
            {
                Name = "Test",
                Value = 10
            };

            for (int i = 0; i < Iterations; i++)
            {
                sut.GetHashCode();
            }
        }
    }
}
