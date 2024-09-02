using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Commands.CreateActuator
{
    public class CreateActuatorCommandHandler : ICommandHandler<CreateActuatorCommand, Actuator>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateActuatorCommandHandler(IEquipmentRepository equipmentRepository, IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Actuator> Handle(CreateActuatorCommand request, CancellationToken cancellationToken)
        {
            Actuator result = new Actuator(
                request.code,
                request.manufacturerName,
                request.physicalMagnitude,
                request.codeAuto,
                Guid.NewGuid());

            _equipmentRepository.AddEquipment(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }

    
    }
}
