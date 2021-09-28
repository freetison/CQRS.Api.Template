using Application.UseCases.CreateOrder;
using AutoMapper;

namespace Application.UseCases.MappingProfiles
{
    class FeatureAccessMapperProfile: Profile
    {
        public FeatureAccessMapperProfile()
        {

            CreateMap<CreateOrderRequest, CreateOrderCommand>();

        }
    }

}
