using AutoMapper;
using Domain;
using Client.Pages;

namespace Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, string>()
               .ConvertUsing(s => s ?? string.Empty);

            CreateMap<SponsorResponseInput, SponsorResponse>()
               .ForMember(
                    dest => dest.C2,
                    opt => opt.MapFrom(
                        src => string.Join(
                            "; ",
                            src.C2))
                );

            CreateMap<ThirdPartyResponseInput, ThirdPartyResponse>()
               .ForMember(
                    dest => dest.DocumentA,
                    opt => opt.Ignore()
                ).ForMember(
                    dest => dest.DocumentB,
                    opt => opt.Ignore()
                ).ForMember(
                    dest => dest.DocumentC,
                    opt => opt.Ignore()
                ).ForMember(
                    dest => dest.DocumentD,
                    opt => opt.Ignore()
                ).ForMember(
                    dest => dest.DocumentE,
                    opt => opt.Ignore()
                ).ForMember(
                    dest => dest.B4C,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.B4C)
                    )
                ).ForMember(
                    dest => dest.D1,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.D1)
                    )
                ).ForMember(
                    dest => dest.D2,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.D2)
                    )
                ).ForMember(
                    dest => dest.D4A,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.D4A)
                    )
                ).ForMember(
                    dest => dest.D4B,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.D4B)
                    )
                ).ForMember(
                    dest => dest.D4C,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.D4C)
                    )
                ).ForMember(
                    dest => dest.D4D,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.D4D)
                    )
                ).ForMember(
                    dest => dest.D6A,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.D6A)
                    )
                ).ForMember(
                    dest => dest.E1B,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.E1B)
                    )
                ).ForMember(
                    dest => dest.G2A,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.G2A)
                    )
                ).ForMember(
                    dest => dest.G2B,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.G2B)
                    )
                ).ForMember(
                    dest => dest.G2C,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.G2C)
                    )
                ).ForMember(
                    dest => dest.G2D,
                    opt => opt.MapFrom(
                        src => string.Join("; ", src.G2D)
                    )
                );
        }
    }
}
