using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConfigStandard
{
    public class ToggleId : IEquatable<ToggleId>
    {
        public string Name { get; protected set; }

        protected ToggleId()
        {
            Name = string.Empty;
        }

        public ToggleId(string name)
        {
            Name = name;
        }

        public bool Equals(ToggleId other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return Name.Equals(other.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is ToggleId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator ==(ToggleId left, ToggleId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ToggleId left, ToggleId right)
        {
            return !Equals(left, right);
        }
    }
}
