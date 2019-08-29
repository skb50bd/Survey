using AutoMapper;
using Domain;
using Web.Pages.Survey;

namespace Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SponsorResponseInput, SponsorResponse>()
               .ForMember(
                    dest => dest.Sponsor,
                    opt => opt.Ignore()
                ).ForMember(
                    dest => dest.SponsorId,
                    opt => opt.Ignore()
                ).ForMember(
                    dest => dest.C2,
                    opt => opt.MapFrom(
                        src => string.Join(
                            ", ",
                            src.C2))
                );
        }
    }
}
