﻿using AdvancedProgrammingNew.Domain.Entities.Equipments;
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

        public Maintenance(string operatorName, Guid id) : base(operatorName, id)
        {
            Actuators = new List<Actuator>();
        }
    }
}
