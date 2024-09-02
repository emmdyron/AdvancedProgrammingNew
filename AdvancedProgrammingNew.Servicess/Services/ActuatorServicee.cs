using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using AutoMapper;

namespace AdvancedProgrammingNew.Servicess.Services
{
    public class ActuatorServicee : Actuator.ActuatorBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ActuatorServicee(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<ActuatorDTO> CreateActuator(CreateActuatorRequest request, ServerCallContext context)
        {
            return base.CreateActuator(request, context);
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


