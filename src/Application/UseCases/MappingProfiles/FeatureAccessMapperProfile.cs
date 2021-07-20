using $safeprojectname$.UseCases.CreateOrder;
using AutoMapper;

namespace $safeprojectname$.UseCases.MappingProfiles
{
    class FeatureAccessMapperProfile: Profile
    {
        public FeatureAccessMapperProfile()
        {

            CreateMap<CreateOrderRequest, CreateOrderCommand>();

        }
    }

}
