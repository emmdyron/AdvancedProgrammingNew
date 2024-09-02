using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Domain.Entities.Types;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Commands.CreateActuator
{
    public record CreateActuatorCommand(string code, string manufacturerName, PhysicalMagnitude physicalMagnitude, string codeAuto) : ICommand<Actuator>;
    
}
