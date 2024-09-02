using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Equipment.Commands.CreateActuator;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Commands.CreateSensor
{
    public class CreateSensorCommandHandler : ICommandHandler<CreateSensorCommand, Sensor>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSensorCommandHandler(IEquipmentRepository equipmentRepository, IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Sensor> Handle(CreateSensorCommand request, CancellationToken cancellationToken)
        {
            Sensor result = new Sensor(
                request.code,
                request.manufacturerName,
                request.physicalMagnitude,
                request.function,
                request.protocol,
                Guid.NewGuid());

            _equipmentRepository.AddEquipment(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }

    }
}
