using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Planifications;
using AdvancedProgrammingNew.Domain.Entities.Planification;

namespace AdvancedProgrammingNew.Application.Planification.Commands.UpdateCalibration
{
    public class UpdateCalibrationCommandHandler : ICommandHandler<UpdateCalibrationCommand>
    {

        private readonly IPlanificationRepository _planificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCalibrationCommandHandler(IPlanificationRepository planificationRepository, IUnitOfWork unitOfWork)
        {
            _planificationRepository = planificationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateCalibrationCommand request, CancellationToken cancellationToken)
        {
            _planificationRepository.UpdatePlanification(request.Calibration);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }

    }
}
