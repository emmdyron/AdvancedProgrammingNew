using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Types;
using AdvancedProgrammingNew.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using AutoMapper;
using MediatR;
using AdvancedProgrammingNew.Application.Equipment.Commands.CreateActuator;

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
                new Domain.Entities.Types.PhysicalMagnitude());
        }

        public override Task<Empty> DeleteActuator(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteActuator(request, context);

        }

        public override Task<Actuator> GetActuator(Empty request, ServerCallContext context)
        {
            return base.GetAllActuator(request, context);
        }

        public override Task<NullableActuatorDTO> GetActuator(GetRequest request, ServerCallContext context)
        {
            return base.GetActuator(request, context);
        }

        public override Task<Empty> UpdateActuator(ActuatorDTO request, ServerCallContext context)
        {
            return base.UpdateActuator(request, context);
        }





    }
}


