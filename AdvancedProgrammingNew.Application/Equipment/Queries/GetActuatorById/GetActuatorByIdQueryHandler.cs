using AdvancedProgrammingNew.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Contracts.Equipments;

namespace AdvancedProgrammingNew.Application.Equipment.Queries.GetActuatorById
{
    public class GetActuatorByIdQueryHandler : IQueryHandler<GetActuatorByIdQuery, Actuator?>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public GetActuatorByIdQueryHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task<Actuator?> Handle(GetActuatorByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_equipmentRepository.GetEquipmentById<Actuator>(request.id));
        }
    }
}
