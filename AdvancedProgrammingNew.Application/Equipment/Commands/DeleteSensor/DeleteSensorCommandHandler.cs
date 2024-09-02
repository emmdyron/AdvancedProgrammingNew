using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Commands.DeleteSensor
{
    public class DeleteSensorCommandHandler : ICommandHandler<DeleteSensorCommand>
    {

        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSensorCommandHandler(IEquipmentRepository equipmentRepository, IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteSensorCommand request, CancellationToken cancellationToken)
        {
            var SensorToDelete = _equipmentRepository.GetEquipmentById<Sensor>(request.id);
            if (SensorToDelete is null)
                return Task.CompletedTask;

            _equipmentRepository.DeleteEquipment(SensorToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }

    }
}
