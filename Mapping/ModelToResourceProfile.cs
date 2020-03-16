using AutoMapper;
using freecodecampapi.Domain.Models;
using freecodecampapi.Extensions;
using freecodecampapi.Resources;

namespace freecodecampapi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Category, IdOfCategoryResource>();
            CreateMap<Product, ProductResource>()
                    .ForMember(src => src.UnitOfMeasurement,
                               opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}