using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;

namespace AdvancedProgrammingNew.Application.Equipment.Commands.DeleteSensor
{
    public record DeleteSensorCommand(Guid id) : ICommand;
}
