using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingNew.Domain.Entities.Planification
{
    public class Maintenance : Planification
    {
        #region Properties

        /// <summary>
        /// Actuador o actuadores sometidos a mantenimiento
        /// </summary>
        public List<Actuator> Actuators { get; set; }

        /// <summary>
        /// Tipo de mantenimiento (Correctivo o Preventivo por ahora)
        /// </summary>
        public MaintenanceTypes MaintenanceType { get; set; }
        #endregion

        protected Maintenance() { }

        public Maintenance(string operatorName, DateTime maintenanceDate, Guid id) : base(operatorName, maintenanceDate, id)
        {
            Actuators = new List<Actuator>();
        }
    }
}
