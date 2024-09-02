using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Domain.Entities.Types;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Application.Equipment.Queries.GetActuatorById;
using AdvancedProgrammingNew.Contracts.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Queries.GetAllActuators
{
    public class GetAllActuatorsQueryHandler : IQueryHandler<GetAllActuatorsQuery, IEnumerable<Actuator>>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public GetAllActuatorsQueryHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task<IEnumerable<Actuator>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_equipmentRepository.GetAllEquipments<Actuator>());
        }
    }
}
