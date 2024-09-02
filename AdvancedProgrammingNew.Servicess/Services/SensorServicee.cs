﻿using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using AutoMapper;

namespace AdvancedProgrammingNew.Servicess.Services
{
    public class SensorServicee : Sensor.SensorBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SensorServicee(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<SensorDTO> CreateSensor(CreateSensorRequest request, ServerCallContext context)
            {
                return base.CreateSensor(request, context);
            }

            public override Task<Empty> DeleteSensor(DeleteRequest request, ServerCallContext context)
            {
                return base.DeleteSensor(request, context);

            }

            public override Task<Sensor> GetSensor(Empty request, ServerCallContext context)
            {
                return base.GetAllSensor(request, context);
            }

            public override Task<NullableSensorDTO> GetSensor(GetRequest request, ServerCallContext context)
            {
                return base.GetSensor(request, context);
            }

            public override Task<Empty> UpdateSensor(SensorDTO request, ServerCallContext context)
            {
                return base.UpdateSensor(request, context);
            }


        
    }
}