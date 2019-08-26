using Domain;
using LiteDB;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repository
{
    public static class MapperConfiguration
    {
        public static BsonMapper ConfigureMapper(this BsonMapper mapper)
        {
            mapper.Entity<SponsorResponse>()
                  .DbRef(sr => sr.Sponsor)
                  .DbRef(sr => sr.Survey)
                  .DbRef(sr => sr.ThirdPartyResponse);

            mapper.Entity<ThirdPartyResponse>()
                  .DbRef(tpr => tpr.ThirdParty)
                  .DbRef(tpr => tpr.Survey)
                  .DbRef(tpr => tpr.SponsorResponse);

            return mapper;
        }
        
    }
}
