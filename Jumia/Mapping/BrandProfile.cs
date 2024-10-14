using AutoMapper;
using Jumia.Models;

namespace Jumia.Mapping
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            //CreateMap<AddBrandViewModel,Brand>()
            //    .ForMember(des => des.BrandName, op => op.MapFrom(src => src.Brand));
        }
    }
}
