namespace afnpires.Benchmarks.DotNet.GetHashCodeImplementation
{
    using System;

    public class PocoWithHashCodeCombine : IEquatable<PocoWithHashCodeCombine>
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as PocoWithHashCodeCombine);
        }

        public bool Equals(PocoWithHashCodeCombine other)
        {
            return !(other is null)
                   && this.Name == other.Name
                   && this.Value == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Value);
        }
    }
}
