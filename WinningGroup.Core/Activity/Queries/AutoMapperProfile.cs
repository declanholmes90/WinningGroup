using AutoMapper;
using WinningGroup.Infrastructure.Entities;
using Attribute = WinningGroup.Infrastructure.Entities.Attribute;

namespace WinningGroup.Core.Activity.Queries
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Attribute, AttributeDto>();
            CreateMap<Fantastic, FantasticDto>();
            CreateMap<Rating, RatingDto>();
        }
    }
}
