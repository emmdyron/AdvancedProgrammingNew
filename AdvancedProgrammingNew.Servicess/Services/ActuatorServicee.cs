using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Types;
using AdvancedProgrammingNew.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using AutoMapper;
using MediatR;
using AdvancedProgrammingNew.Application.Equipment.Commands.CreateActuator;
using AdvancedProgrammingNew.Application.Equipment.Commands.DeleteActuator;
using AdvancedProgrammingNew.Application.Equipment.Queries.GetAllActuators;
using AdvancedProgrammingNew.Application.Equipment.Queries.GetActuatorById;
using AdvancedProgrammingNew.Application.Equipment.Commands.UpdateActuator;

namespace AdvancedProgrammingNew.Servicess.Services
{
    public class ActuatorServices : Actuator.ActuatorBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ActuatorServices(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<ActuatorDTO> CreateActuator(CreateActuatorRequest request, ServerCallContext context)
        {
            var command = new CreateActuatorCommand(
                request.Code,
                request.ManufacturerName,
                new Domain.Entities.Types.PhysicalMagnitude(request.PhysicalMagnitude.Name, request.PhysicalMagnitude.MeasurementUnit),
                request.CodeAuto);
                

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<ActuatorDTO>(result));
        }

        public override Task<Empty> DeleteActuator(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteActuatorCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Actuators> GetAllActuator(Empty request, ServerCallContext context)
        {
            var query = new GetAllActuatorsQuery();

            var result = _mediator.Send(query).Result;

            var actuatorsDTO = new Actuators();
            actuatorsDTO.Items.AddRange(result.Select(e => _mapper.Map<ActuatorDTO>(e)));

            return Task.FromResult(actuatorsDTO);
        }

        public override Task<NullableActuatorDTO> GetActuator(GetRequest request, ServerCallContext context)
        {
            var query = new GetActuatorByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableActuatorDTO() { Null = NullValue.NullValue });

            return Task.FromResult(new NullableActuatorDTO() { Actuator = _mapper.Map<ActuatorDTO>(result)});
        }

        public override Task<Empty> UpdateActuator(ActuatorDTO request, ServerCallContext context)
        {
            var command = new UpdateActuatorCommand(_mapper.Map<Domain.Entities.Equipments.Actuator>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }





    }
}


