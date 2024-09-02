using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Domain.Entities.Types;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Commands.CreateSensor
{
    public record CreateSensorCommand(string code, string manufacturerName, PhysicalMagnitude physicalMagnitude, string function, Protocol protocol) : ICommand<Sensor>;

}
