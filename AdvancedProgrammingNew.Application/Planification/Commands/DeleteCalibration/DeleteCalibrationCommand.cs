using AdvancedProgrammingNew.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingNew.Application.Planification.Commands.DeleteCalibration
{
    public record DeleteCalibrationCommand(Guid id) : ICommand;
}
