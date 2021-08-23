using AutoMapper;
using NEXOSAPI.Domain.Entities;
using NEXOSAPI.Infrastructure.ViewModel;

namespace NEXOSAPI.Infrastructure.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //CreateMap<CustomerModel, Customer>()
            //    .ForMember(dest => dest.Id,
            //            opt => opt.MapFrom(src => src.CustomerId))
            //    .ReverseMap();
        }
    }
}
