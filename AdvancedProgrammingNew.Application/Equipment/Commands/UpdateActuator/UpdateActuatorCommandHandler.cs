using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Application.Equipment.Commands.DeleteSensor;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Commands.UpdateActuator
{
    public class UpdateActuatorCommandHandler : ICommandHandler<UpdateActuatorCommand>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateActuatorCommandHandler(IEquipmentRepository equipmentRepository, IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateActuatorCommand request, CancellationToken cancellationToken)
        {
            _equipmentRepository.UpdateEquipment(request.Actuator);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }

    }
}