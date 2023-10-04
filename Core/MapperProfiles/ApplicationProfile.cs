using AutoMapper;
using Core.Dtos.Amount;
using Core.Dtos.Brand;
using Core.Dtos.Parfume;
using Core.Dtos.Perfume;
using Core.Dtos;
using Core.Dtos.User;
using System.Drawing;
using Core.Entities;
using Core.Entities;

namespace Core.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();
            CreateMap<UserEntity, GetUserDTO>();

            CreateMap<Amount, AmountDTO>().ReverseMap();
            CreateMap<Amount, CreateAmountDTO>().ReverseMap();

            CreateMap<ProductDTO, ProductEntity>().ReverseMap();
            CreateMap<CreateProductDTO, ProductEntity>().ReverseMap();
            CreateMap<EditProductDTO, ProductEntity>().ReverseMap();
            CreateMap<EditUserDTO, UserEntity>()
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture != null ? Path.GetRandomFileName() : null));
        }
    }
}
