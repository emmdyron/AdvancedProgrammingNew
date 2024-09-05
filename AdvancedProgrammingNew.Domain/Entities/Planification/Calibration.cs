using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Domain.Entities.Planification
{
    public class Calibration : Planification
    {
        #region Properties


        /// <summary>
        /// Sensor o sensores sometidos a calibracion
        /// </summary>
        public List<Sensor> Sensors { get; set; }


        /// <summary>
        /// Entidad certificadora de la calibracion
        /// </summary>
        public string Certifier { get; }

        #endregion

        protected Calibration() { }

        public Calibration(string certifier, string operatorName, DateTime maintenanceDate, Guid id) : base(operatorName, maintenanceDate, id)
        {
            Sensors = new List<Sensor>();
            Certifier = certifier;
        }
    }
}
