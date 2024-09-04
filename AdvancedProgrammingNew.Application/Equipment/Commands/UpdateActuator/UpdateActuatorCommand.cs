﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Commands.UpdateActuator
{
    public record UpdateActuatorCommand(Actuator Actuator) : ICommand;
    
    
}