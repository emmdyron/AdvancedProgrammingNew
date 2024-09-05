using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Planifications;
using AdvancedProgrammingNew.Domain.Entities.Planification;

namespace AdvancedProgrammingNew.Application.Planification.Commands.CreateCalibration
{
    public class CreateCalibrationCommandHandler : ICommandHandler<CreateCalibrationCommand, Calibration>
    {
        private readonly IPlanificationRepository _planificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCalibrationCommandHandler(IPlanificationRepository planificationRepository, IUnitOfWork unitOfWork)
        {
            _planificationRepository = planificationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Calibration> Handle(CreateCalibrationCommand request, CancellationToken cancellationToken)
        {
            Calibration result = new Calibration(
                request.certifier,
                request.operatorName,
                request.maintenanceDate,
                Guid.NewGuid());

            _planificationRepository.AddPlanification(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }


    }
}
