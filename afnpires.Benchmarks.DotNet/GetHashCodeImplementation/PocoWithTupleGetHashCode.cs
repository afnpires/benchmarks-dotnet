namespace afnpires.Benchmarks.DotNet.GetHashCodeImplementation
{
    using System;

    public class PocoWithTupleGetHashCode : IEquatable<PocoWithTupleGetHashCode>
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as PocoWithTupleGetHashCode);
        }

        public bool Equals(PocoWithTupleGetHashCode other)
        {
            return !(other is null)
                   && this.Name == other.Name
                   && this.Value == other.Value;
        }

        public override int GetHashCode()
        {
            // https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode/4630550#4630550
            return (Name, Value).GetHashCode();
        }
    }
}
