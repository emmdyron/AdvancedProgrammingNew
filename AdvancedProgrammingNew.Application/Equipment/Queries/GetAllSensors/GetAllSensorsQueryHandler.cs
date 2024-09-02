using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Domain.Entities.Types;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Application.Equipment.Queries.GetAllActuators;
using AdvancedProgrammingNew.Contracts.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Queries.GetAllSensors
{
    public class GetAllSensorsQueryHandler : IQueryHandler<GetAllSensorsQuery, IEnumerable<Sensor>>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public GetAllSensorsQueryHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task<IEnumerable<Sensor>> Handle(GetAllSensorsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_equipmentRepository.GetAllEquipments<Sensor>());
        }
    }
}
