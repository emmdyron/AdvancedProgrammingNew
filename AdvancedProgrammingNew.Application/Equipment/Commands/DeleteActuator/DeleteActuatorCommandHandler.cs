using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Commands.DeleteActuator
{
    public class DeleteActuatorCommandHandler : ICommandHandler<DeleteActuatorCommand>
    {

        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteActuatorCommandHandler(IEquipmentRepository equipmentRepository, IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteActuatorCommand request, CancellationToken cancellationToken)
        { 
            var ActuatorToDelete = _equipmentRepository.GetEquipmentById<Actuator>(request.id);
            if (ActuatorToDelete is null)
                return Task.CompletedTask;

            _equipmentRepository.DeleteEquipment(ActuatorToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }

    }
}
