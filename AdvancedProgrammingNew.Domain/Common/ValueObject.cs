using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingNew.Domain.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GerEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GerEqualityComponents().SequenceEqual(other.GerEqualityComponents());
        }
    }
}
