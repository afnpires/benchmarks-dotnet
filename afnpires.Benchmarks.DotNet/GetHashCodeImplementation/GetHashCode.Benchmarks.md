# GetHashCode() Benchmarks

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.285 (1803/April2018Update/Redstone4)
Intel Core i7-8550U CPU 1.80GHz (Max: 1.79GHz) (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
Frequency=1945310 Hz, Resolution=514.0569 ns, Timer=TSC
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT


```
|                     Method |      Mean |     Error |    StdDev |       Min |       Max | Allocated |
|--------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|
|           TupleGetHashCode | 13.208 us | 0.0542 us | 0.0507 us | 13.142 us | 13.311 us |      32 B |
|       UncheckedGetHashCode |  8.218 us | 0.0497 us | 0.0440 us |  8.123 us |  8.275 us |      32 B |
| HashCodeCombineGetHashCode | 10.561 us | 0.0691 us | 0.0646 us | 10.448 us | 10.680 us |      32 B |
