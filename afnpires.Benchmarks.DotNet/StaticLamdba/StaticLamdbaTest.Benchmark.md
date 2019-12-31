``` ini

BenchmarkDotNet=v0.11.1, OS=ubuntu 18.04
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.802
  [Host]     : .NET Core 2.1.14 (CoreCLR 4.6.28207.04, CoreFX 4.6.28208.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.14 (CoreCLR 4.6.28207.04, CoreFX 4.6.28208.01), 64bit RyuJIT


```
|                     Method |     Mean |     Error |    StdDev |   Gen 0 | Allocated |
|--------------------------- |---------:|----------:|----------:|--------:|----------:|
|                 WithLamdba | 65.93 us | 0.4784 us | 0.4241 us | 38.0859 | 156.25 KB |
| WithLamdbaWithoutExtension | 69.17 us | 1.5520 us | 2.5930 us | 38.0859 | 156.25 KB |
|                     Inline | 76.75 us | 0.4761 us | 0.4221 us | 53.3447 | 218.75 KB |
