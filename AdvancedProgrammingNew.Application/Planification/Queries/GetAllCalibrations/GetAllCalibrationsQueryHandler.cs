using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Contracts.Planifications;
using AdvancedProgrammingNew.Domain.Entities.Planification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingNew.Application.Planification.Queries.GetAllCalibrations
{
    public class GetAllCalibrationsQueryHandler : IQueryHandler<GetAllCalibrationsQuery, IEnumerable<Calibration>>
    {
        private readonly IPlanificationRepository _planificationRepository;

        public GetAllCalibrationsQueryHandler(IPlanificationRepository planificationRepository)
        {
            _planificationRepository = planificationRepository;
        }

        public Task<IEnumerable<Calibration>> Handle(GetAllCalibrationsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_planificationRepository.GetAllPlanifications<Calibration>());
        }
    }
}
