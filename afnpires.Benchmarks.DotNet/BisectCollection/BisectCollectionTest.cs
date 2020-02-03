namespace afnpires.Benchmarks.DotNet.BisectCollection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    [MarkdownExporter]
    public class BisectCollectionTest
    {
        private List<Item> items = CreateItemList(1000).ToList();
        private const int Iterations = 100;

        [Benchmark]
        public void FilterAndExcept()
        {
            for (var i = 0; i < Iterations; i++)
            {
                var valid = items.Where(item =>
                    ItemCategory.Valid.Equals(item.Category, StringComparison.InvariantCultureIgnoreCase)).ToList();
                var invalid = items.Except(valid).ToList();
            }
        }

        [Benchmark]
        public void GroupIntoDictionary()
        {
            for (var i = 0; i < Iterations; i++)
            {
                var filteredItems = items
                    .GroupBy(item =>
                        ItemCategory.Valid.Equals(item.Category, StringComparison.InvariantCultureIgnoreCase))
                    .ToDictionary(k => k.Key, v => v.ToList());
                var valid = filteredItems[true];
                var invalid = filteredItems[false];
            }
        }

        [Benchmark]
        public void Reduce()
        {
            for (var i = 0; i < Iterations; i++)
            {
                var (valid, invalid) = items.Aggregate(
                    new Tuple<List<Item>, List<Item>>(new List<Item>(items.Capacity), new List<Item>(items.Capacity)),
                    (holder, item) =>
                    {
                        if (ItemCategory.Valid.Equals(item.Category, StringComparison.InvariantCultureIgnoreCase))
                        {
                            holder.Item1.Add(item);
                        }
                        else
                        {
                            holder.Item2.Add(item);
                        }

                        return holder;
                    }
                );
            }
        }

        [Benchmark]
        public void ReduceDictionary()
        {
            for (var i = 0; i < Iterations; i++)
            {
                var result = items.Aggregate(
                    new Dictionary<bool, List<Item>>
                    {
                        { true, new List<Item>(items.Capacity) },
                        { false, new List<Item>(items.Capacity)}
                    },
                    (holder, item) =>
                    {
                        holder[ItemCategory.Valid.Equals(item.Category, StringComparison.InvariantCultureIgnoreCase)].Add(item);

                        return holder;
                    }
                );

                var valid = result[true];
                var invalid = result[false];
            }
        }

        [Benchmark]
        public void PlainHoldForEach()
        {
            for (var i = 0; i < Iterations; i++)
            {
                var valid = new List<Item>(items.Capacity);
                var invalid = new List<Item>(items.Capacity);

                foreach (var item in items)
                {
                    if (ItemCategory.Valid.Equals(item.Category, StringComparison.InvariantCultureIgnoreCase))
                    {
                        valid.Add(item);
                    }
                    else
                    {
                        invalid.Add(item);
                    }
                }
            }
        }

        private static IEnumerable<Item> CreateItemList(int numElements)
        {
            for (var i = 0; i < numElements; i++)
            {
                yield return new Item
                {
                    Category = i % 2 == 0 ? "Valid" : "Invalid"
                };
            }
        }
    }

    public class Item
    {
        public string Category { get; set; }
    }

    public static class ItemCategory
    {
        public const string Valid = "valid";
    }
}
