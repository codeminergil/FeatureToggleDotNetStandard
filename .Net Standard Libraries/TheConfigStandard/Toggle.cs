using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConfigStandard
{
    using System;

    public class Toggle : IEquatable<Toggle>
    {
        private readonly bool empty;

        public string Name { get; protected set; }

        public bool IsEnabled { get; }

        public static Toggle Empty => new Toggle();

        private Toggle()
        {
            Name = string.Empty;
            IsEnabled = false;
            empty = true;
        }

        public Toggle(string name, bool enabled)
        {
            Name = name;
            IsEnabled = enabled;
            empty = false;
        }

        public static bool IsNullOrEmpty(Toggle toggle)
        {
            if (toggle == null)
            {
                return true;
            }

            return toggle.empty;
        }

        public bool Equals(Toggle other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return empty == other.empty && string.Equals(Name, other.Name) && IsEnabled == other.IsEnabled;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Toggle)obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator ==(Toggle left, Toggle right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Toggle left, Toggle right)
        {
            return !Equals(left, right);
        }
    }
}
