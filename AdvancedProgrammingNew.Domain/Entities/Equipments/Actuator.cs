using AdvancedProgrammingNew.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingNew.Domain.Entities.Equipments
{
    public class Actuator : Equipment
    {
        #region Properties
        /// <summary>
        /// Ver si es digital o analogico
        /// </summary>
        public bool IsDigital { get; set; }

        /// <summary>
        /// Codigo del automata que lo controla
        /// </summary>

        public string CodeAuto { get; }


        #endregion

        protected Actuator() { }

        public Actuator(string code, string manufacturerName, PhysicalMagnitude physicalMagnitude, string codeAuto, Guid id) : base(code, manufacturerName, physicalMagnitude, id)
        {
            IsDigital = false;
            CodeAuto = codeAuto;
        }
    }
}

