﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingNew.Domain.Entities.Planification
{
    public class Planification : Entity
    {

        #region Properties

        /// <summary>
        /// Fecha de mantenimiento
        /// </summary>
        public DateTime MaintenanceDate { get; set; }

        /// <summary>
        /// Nombre del operador encargado del mantenimiento
        /// </summary>
        public string OperatorName { get; set; }

        #endregion

        public Planification(string operatorName, Guid id) : base(id)
        {
            OperatorName = operatorName;
        }

    }
}
