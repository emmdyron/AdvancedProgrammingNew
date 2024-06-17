using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingNew.Domain.Entities.Types
{
    public class PhysicalMagnitude : ValueObject
    {

        #region Properties

        /// <summary>
        /// Nombre de la magnitud fisica
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// Unidad de medida
        /// </summary>

        public string MeasurementUnit { get; set; }

        #endregion

        protected PhysicalMagnitude() { }

        public PhysicalMagnitude(string name, string measurementunit)
        {
            Name = name;
            MeasurementUnit = measurementunit;
        }

        protected override IEnumerable<object> GerEqualityComponents()
        {
            yield return Name;
            yield return MeasurementUnit;
        }

    }

}
