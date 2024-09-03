using AutoMapper;
using AdvancedProgrammingNew.Protos;
using AdvancedProgrammingNew.Domain;

namespace AdvancedProgrammingNew.Servicess.Mappers
{
    public class SensorProfile : Profile
    {

        public SensorProfile()
        {

            CreateMap<Domain.Entities.Equipments.Sensor,
                Protos.SensorDTO>()
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.ManufacturerName, o => o.MapFrom(s => s.ManufacturerName))
                .ForMember(t => t.PhysicalMagnitude, o => o.MapFrom(s => (Protos.PhysicalMagnitude)s.PhysicalMagnitude))
                .ForMember(t => t.Function, o => o.MapFrom(s => s.Function))
                .ForMember(t => t.Protocol, o => o.MapFrom(s => (Protos.Protocol)s.Protocol))
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()));



            CreateMap<Protos.SensorDTO,
                Domain.Entities.Equipments.Sensor>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.ManufacturerName, o => o.MapFrom(s => s.ManufacturerName))
                .ForMember(t => t.PhysicalMagnitude, o => o.MapFrom(s => (Domain.Entities.Types.PhysicalMagnitude)s.PhysicalMagnitude))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.Function, o => o.MapFrom(s => s.Function))
                .ForMember(t => t.Protocol, o => o.MapFrom(s => (Domain.Entities.Types.Protocol)s.Protocol));
                
        }
    }
}