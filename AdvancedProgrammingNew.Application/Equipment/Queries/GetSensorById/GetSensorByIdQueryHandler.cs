using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Application.Equipment.Queries.GetActuatorById;

namespace AdvancedProgrammingNew.Application.Equipment.Queries.GetSensorById
{
    public class GetSensorByIdQueryHandler : IQueryHandler<GetSensorByIdQuery, Sensor?>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public GetSensorByIdQueryHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task<Sensor?> Handle(GetSensorByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_equipmentRepository.GetEquipmentById<Sensor>(request.id));
        }
    }
}
