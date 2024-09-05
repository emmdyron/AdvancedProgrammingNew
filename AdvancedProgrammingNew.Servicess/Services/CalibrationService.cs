using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Types;
using AdvancedProgrammingNew.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using AutoMapper;
using MediatR;
using AdvancedProgrammingNew.Application.Planification.Commands.CreateCalibration;
using AdvancedProgrammingNew.Application.Planification.Queries.GetCalibrationById;
using AdvancedProgrammingNew.Application.Planification.Queries.GetAllCalibrations;
using AdvancedProgrammingNew.Application.Planification.Commands.UpdateCalibration;
using AdvancedProgrammingNew.Application.Planification.Commands.DeleteCalibration;

namespace AdvancedProgrammingNew.Servicess.Services
{
    public class CalibrationServices : Calibration.CalibrationBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CalibrationServices(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<CalibrationDTO> CreateCalibration(CreateCalibrationRequest request, ServerCallContext context)
        {
            var command = new CreateCalibrationCommand(
                request.Certfier,
                request.OperatorName,
                DateTime.Now);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<CalibrationDTO>(result));
        }

        public override Task<NullableCalibrationDTO> GetCalibration(GetRequest request, ServerCallContext context)
        {
            var query = new GetCalibrationByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableCalibrationDTO() { Null = NullValue.NullValue });

            return Task.FromResult(new NullableCalibrationDTO() { Calibration = _mapper.Map<CalibrationDTO>(result) });
        }

        public override Task<Calibrations> GetAllCalibration(Empty request,  ServerCallContext context)
        {
            var query = new GetAllCalibrationsQuery();

            var result = _mediator.Send(query).Result;

            var calibrationsDTO = new Calibrations();
            calibrationsDTO.Items.AddRange(result.Select(e => _mapper.Map<CalibrationDTO>(e)));

            return Task.FromResult(calibrationsDTO);
        }

        public override Task<Empty> UpdateCalibration(CalibrationDTO request,  ServerCallContext context)
        {
            var command = new UpdateCalibrationCommand(_mapper.Map<Domain.Entities.Planification.Calibration>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteCalibration(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteCalibrationCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

    }
}
