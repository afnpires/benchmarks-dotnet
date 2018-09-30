namespace afnpires.Benchmarks.DotNet.GetHashCodeImplementation
{
    using System;

    public class PocoWithUncheckedGetHashCode : IEquatable<PocoWithUncheckedGetHashCode>
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public bool Equals(PocoWithUncheckedGetHashCode other)
        {
            return !(other is null)
                   && this.Name == other.Name
                   && this.Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as PocoWithUncheckedGetHashCode);
        }

        public override int GetHashCode()
        {
            // http://www.loganfranken.com/blog/692/overriding-equals-in-c-part-2/
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ ((this.Name is null) ? 0 : Name.GetHashCode());
                hash = (hash * HashingMultiplier) ^ this.Value.GetHashCode();
                return hash;
            }
        }
    }
}
