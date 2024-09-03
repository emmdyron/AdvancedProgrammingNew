using AutoMapper;
using AdvancedProgrammingNew.Protos;
using AdvancedProgrammingNew.Domain;

namespace AdvancedProgrammingNew.Servicess.Mappers
{
    public class ActuatorProfile : Profile
    {

        public ActuatorProfile()
        {

            CreateMap<Domain.Entities.Equipments.Actuator,
                Protos.ActuatorDTO>()
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.ManufacturerName, o => o.MapFrom(s => s.ManufacturerName))
                .ForMember(t => t.PhysicalMagnitude, o => o.MapFrom(s => new Protos.PhysicalMagnitude()
                {
                    Name = s.PhysicalMagnitude.Name,
                    MeasurementUnit = s.PhysicalMagnitude.MeasurementUnit,
                }))
                .ForMember(t => t.CodeAuto, o => o.MapFrom(s => s.CodeAuto))
                .ForMember(t => t.IsDigital, o => o.MapFrom(s => s.IsDigital))
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()));



            CreateMap<Protos.ActuatorDTO,
                Domain.Entities.Equipments.Actuator>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.ManufacturerName, o => o.MapFrom(s => s.ManufacturerName))
                .ForMember(t => t.PhysicalMagnitude, o => o.MapFrom(s => new Protos.PhysicalMagnitude()
                {
                    Name = s.PhysicalMagnitude.Name,
                    MeasurementUnit = s.PhysicalMagnitude.MeasurementUnit,
                }))
                .ForMember(t => t.CodeAuto, o => o.MapFrom(s => s.CodeAuto))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.IsDigital, o => o.MapFrom(s => s.IsDigital));
        }
}
}