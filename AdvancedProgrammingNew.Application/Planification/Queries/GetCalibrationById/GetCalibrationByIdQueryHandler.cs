using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Application.Equipment.Queries.GetActuatorById;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Contracts.Planifications;
using AdvancedProgrammingNew.Domain.Entities.Planification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingNew.Application.Planification.Queries.GetCalibrationById
{
    public class GetCalibrationByIdQueryHandler : IQueryHandler<GetCalibrationByIdQuery, Calibration?>
    {
        private readonly IPlanificationRepository _planificationRepository;

        public GetCalibrationByIdQueryHandler(IPlanificationRepository planificationRepository)
        {
            _planificationRepository = planificationRepository;
        }

        public Task<Calibration?> Handle(GetCalibrationByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_planificationRepository.GetPlanificationById<Calibration>(request.id));
        }
    }
}
