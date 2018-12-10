namespace afnpires.Benchmarks.DotNet.Collections
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnostics.Windows.Configs;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    [InliningDiagnoser]
    [MinColumn]
    [MaxColumn]
    [MarkdownExporter]
    [RPlotExporter]
    public class ListTest
    {
        public const int Iterations = 1000;

        [Benchmark]
        public static void ListEnumeration()
        {
            List<int> list = new List<int>();

            for (var i = 0; i < Iterations; i++)
            {
                foreach (var item in list) { }
            }
        }

        [Benchmark]
        public static void IListEnumeration()
        {
            IList<int> list = new List<int>();

            for (var i = 0; i < Iterations; i++)
            {
                foreach (var item in list) { }
            }
        }

        [Benchmark]
        public static void VarEnumeration()
        {
            var list = new List<int>();

            for (var i = 0; i < Iterations; i++)
            {
                foreach (var item in list) { }
            }
        }

        [Benchmark]
        public static void IEnumerableEnumeration()
        {
            IEnumerable<int> list = new List<int>();

            for (var i = 0; i < Iterations; i++)
            {
                foreach (var item in list) { }
            }
        }

        [Benchmark]
        public static void IReadOnlyCollectionEnumeration()
        {
            IReadOnlyCollection<int> list = new List<int>();

            for (var i = 0; i < Iterations; i++)
            {
                foreach (var item in list) { }
            }
        }

        [Benchmark]
        public static void IReadOnlyListEnumeration()
        {
            IReadOnlyList<int> list = new List<int>();

            for (var i = 0; i < Iterations; i++)
            {
                foreach (var item in list) { }
            }
        }

        private static IList<int> GetIList() => new List<int>();

        private static List<int> GetList() => new List<int>();

        [Benchmark]
        public static void IListMethodEnumeration()
        {
            IList<int> list = GetIList();

            for (var i = 0; i < Iterations; i++)
            {
                foreach (var item in list) { }
            }
        }

        [Benchmark]
        public static void VarIListMethodEnumeration()
        {
            var list = GetIList();

            for (var i = 0; i < Iterations; i++)
            {
                foreach (var item in list) { }
            }
        }

        [Benchmark]
        public static void ListMethodEnumeration()
        {
            IList<int> list = GetList();

            for (var i = 0; i < Iterations; i++)
            {
                foreach (var item in list) { }
            }
        }

        [Benchmark]
        public static void VarListMethodEnumeration()
        {
            var list = GetList();

            for (var i = 0; i < Iterations; i++)
            {
                foreach (var item in list) { }
            }
        }
    }
}
