namespace afnpires.Benchmarks.DotNet
{
    using afnpires.Benchmarks.DotNet.Collections;
    using afnpires.Benchmarks.DotNet.GetHashCodeImplementation;
    using BenchmarkDotNet.Running;

    public class Program
    {
        public static void Main()
        {
            //var summary = BenchmarkRunner.Run<GetHashCodeTest>();
            var summary = BenchmarkRunner.Run<ListTest>();
        }
    }
}
