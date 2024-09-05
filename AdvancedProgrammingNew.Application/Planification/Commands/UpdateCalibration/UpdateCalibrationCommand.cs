using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Domain.Entities.Planification;

namespace AdvancedProgrammingNew.Application.Planification.Commands.UpdateCalibration
{
    public record UpdateCalibrationCommand(Calibration Calibration) : ICommand;
}
