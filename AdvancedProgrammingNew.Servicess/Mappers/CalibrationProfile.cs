using AutoMapper;
using AdvancedProgrammingNew.Protos;
using AdvancedProgrammingNew.Domain;

namespace AdvancedProgrammingNew.Servicess.Mappers
{
    public class CalibrationProfile : Profile
    {
        public CalibrationProfile()
        {
            CreateMap<Domain.Entities.Planification.Calibration, Protos.CalibrationDTO>()
                .ForMember(t => t.Certfier, o => o.MapFrom(s => s.Certifier))
                .ForMember(t => t.OperatorName, o => o.MapFrom(s => s.OperatorName))
                .ForMember(t => t.MaintenanceDate, o => o.MapFrom(s => s.MaintenanceDate))
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()));

            CreateMap<Protos.CalibrationDTO, Domain.Entities.Planification.Calibration>()
                .ForMember(t => t.Certifier, o => o.MapFrom(s => s.Certfier))
                .ForMember(t => t.OperatorName, o => o.MapFrom(s => s.OperatorName))
                .ForMember(t => t.MaintenanceDate, o => o.MapFrom(s => s.MaintenanceDate))
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)));

        }
    }
}
