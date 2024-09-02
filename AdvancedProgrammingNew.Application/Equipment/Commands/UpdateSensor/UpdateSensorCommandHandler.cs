using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Commands.UpdateSensor
{
    public class UpdateSensorCommandHandler : ICommandHandler<UpdateSensorCommand>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSensorCommandHandler(IEquipmentRepository equipmentRepository, IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateSensorCommand request, CancellationToken cancellationToken)
        {
            _equipmentRepository.UpdateEquipment(request.Sensor);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }

    }
}