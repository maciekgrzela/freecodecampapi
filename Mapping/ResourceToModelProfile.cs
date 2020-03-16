using AutoMapper;
using freecodecampapi.Domain.Models;
using freecodecampapi.Resources;

namespace freecodecampapi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}