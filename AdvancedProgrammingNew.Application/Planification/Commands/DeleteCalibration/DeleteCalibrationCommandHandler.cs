using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Application.Abstract;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Planifications;
using AdvancedProgrammingNew.Domain.Entities.Planification;

namespace AdvancedProgrammingNew.Application.Planification.Commands.DeleteCalibration
{
    public class DeleteCalibrationCommandHandler : ICommandHandler<DeleteCalibrationCommand>
    {

        private readonly IPlanificationRepository _planificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCalibrationCommandHandler(IPlanificationRepository planificationRepository, IUnitOfWork unitOfWork)
        {
            _planificationRepository = planificationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteCalibrationCommand request, CancellationToken cancellationToken)
        {
            var calibrationToDelete = _planificationRepository.GetPlanificationById<Calibration>(request.id);
            if (calibrationToDelete is null)
                return Task.CompletedTask;

            _planificationRepository.DeletePlanification(calibrationToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }

    }
}
