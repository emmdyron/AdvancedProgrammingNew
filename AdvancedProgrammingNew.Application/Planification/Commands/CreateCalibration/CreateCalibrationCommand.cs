using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Domain.Entities.Types;
using AdvancedProgrammingNew.Domain.Entities.Planification;

namespace AdvancedProgrammingNew.Application.Planification.Commands.CreateCalibration
{
    public record CreateCalibrationCommand(string certifier, string operatorName, DateTime maintenanceDate) : ICommand<Calibration>;
}
