using System.Collections.Generic;
using System.Linq;

namespace afnpires.Benchmarks.DotNet.StaticLamdba
{
    using BenchmarkDotNet.Attributes;
    
    [MemoryDiagnoser]
    [MarkdownExporter]
    public class StaticLamdbaTest
    {
        public List<int> values = new List<int> { 1, 2, 3, 4, 5 };
        public const int Iterations = 1000;

        [Benchmark]
        public void WithLamdba()
        {
            for (int i = 0; i < Iterations; i++)
            {
                var trasnformation = values.Select(n => n.Add()).ToList();
            }
            
        }    
        
        [Benchmark]
        public void WithLamdbaWithoutExtension()
        {
            for (int i = 0; i < Iterations; i++)
            {
                var trasnformation = values.Select(n => ExtensionMethod.Add(n)).ToList();
            }
            
        }  
        
        [Benchmark]
        public void Inline()
        {
            for (int i = 0; i < Iterations; i++)
            {
                var trasnformation = values.Select(ExtensionMethod.Add).ToList();                
            }
        }
    }

    public static class ExtensionMethod
    {
        public static int Add(this int i) => i + 1;
    }
}
