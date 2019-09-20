``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17763
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.203
  [Host]     : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), 64bit RyuJIT


```
|                   Method |     Mean |     Error |    StdDev |   Median |      Min |      Max |     Gen 0 | Allocated |
|------------------------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|----------:|
|         ToStringThenJson | 3.037 ms | 0.0722 ms | 0.2082 ms | 3.030 ms | 2.679 ms | 3.582 ms |  738.2813 |   2.96 MB |
| InlineMemoryStreamReader | 3.380 ms | 0.0670 ms | 0.1258 ms | 3.348 ms | 3.136 ms | 3.672 ms | 1601.5625 |   6.41 MB |
|       MemoryStreamReader | 3.087 ms | 0.0799 ms | 0.2317 ms | 3.025 ms | 2.762 ms | 3.708 ms | 1488.2813 |   5.97 MB |
|   MemoryStreamJsonReader | 2.869 ms | 0.0537 ms | 0.0449 ms | 2.877 ms | 2.768 ms | 2.931 ms | 1437.5000 |   5.75 MB |
