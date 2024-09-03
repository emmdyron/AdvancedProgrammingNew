using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Types;
using AdvancedProgrammingNew.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using AutoMapper;
using MediatR;
using AdvancedProgrammingNew.Application.Equipment.Commands.CreateSensor;
using AdvancedProgrammingNew.Application.Equipment.Commands.DeleteActuator;
using AdvancedProgrammingNew.Application.Equipment.Commands.DeleteSensor;
using AdvancedProgrammingNew.Application.Equipment.Queries.GetAllActuators;
using AdvancedProgrammingNew.Application.Equipment.Queries.GetAllSensors;
using AdvancedProgrammingNew.Application.Equipment.Queries.GetActuatorById;
using AdvancedProgrammingNew.Application.Equipment.Queries.GetSensorById;
using AdvancedProgrammingNew.Application.Equipment.Commands.UpdateActuator;
using AdvancedProgrammingNew.Application.Equipment.Commands.UpdateSensor;

namespace AdvancedProgrammingNew.Servicess.Services
{
    public class SensorServices : Sensor.SensorBase
    {
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public SensorServices(
                IMediator mediator,
                IMapper mapper)
            {
                _mediator = mediator;
                _mapper = mapper;
            }

            public override Task<SensorDTO> CreateSensor(CreateSensorRequest request, ServerCallContext context)
            {
                var command = new CreateSensorCommand(
                request.Code,
                request.ManufacturerName,
                new Domain.Entities.Types.PhysicalMagnitude(request.PhysicalMagnitude.Name, request.PhysicalMagnitude.MeasurementUnit),
                request.Function,
                (Domain.Entities.Types.Protocol)request.Protocol);

                var result = _mediator.Send(command).Result;

                return Task.FromResult(_mapper.Map<SensorDTO>(result));
            }

            public override Task<Empty> DeleteSensor(DeleteRequest request, ServerCallContext context)
            {
                var command = new DeleteSensorCommand(new Guid(request.Id));

                _mediator.Send(command);

                return Task.FromResult(new Empty());
            }

            public override Task<Sensors> GetAllSensor(Empty request, ServerCallContext context)
            {
                var query = new GetAllSensorsQuery();

                var result = _mediator.Send(query).Result;

                var sensorsDTO = new Sensors();
                sensorsDTO.Items.AddRange(result.Select(e => _mapper.Map<SensorDTO>(e)));

                return Task.FromResult(sensorsDTO);
            }

            public override Task<NullableSensorDTO> GetSensor(GetRequest request, ServerCallContext context)
            {
                var query = new GetSensorByIdQuery(new Guid(request.Id));

                var result = _mediator.Send(query).Result;

                if (result is null)
                    return Task.FromResult(new NullableSensorDTO() { Null = NullValue.NullValue });

                return Task.FromResult(new NullableSensorDTO() { Sensor = _mapper.Map<SensorDTO>(result) });
            }

            public override Task<Empty> UpdateSensor(SensorDTO request, ServerCallContext context)
            {
                var command = new UpdateSensorCommand(_mapper.Map<Domain.Entities.Equipments.Sensor>(request));

                _mediator.Send(command);

                return Task.FromResult(new Empty());
            }


        
    }
}