using AutoMapper;
using Core.Dtos.Amount;
using Core.Dtos.Brand;
using Core.Dtos.Parfume;
using Core.Dtos.Perfume;
using Core.Dtos;
using Core.Dtos.User;
using System.Drawing;
using Core.Entities;
using Core.Dtos.Category;
using Core.Dtos.ParfumePiece;
using Core.Dtos.Product;

namespace Core.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();

            CreateMap<Amount, AmountDTO>().ReverseMap();
            CreateMap<Amount, CreateAmountDTO>().ReverseMap();

            CreateMap<ProductDTO, ProductEntity>().ReverseMap();
            CreateMap<CreateProductDTO, ProductEntity>().ReverseMap();
            CreateMap<EditProductDTO, ProductEntity>().ReverseMap();
            CreateMap<ProductEntity, CreateProductParfumeDTO>()
                .ForMember(dest => dest.ParfumePieces, opt => opt.Ignore());
            CreateMap<CreateProductParfumeDTO, ProductEntity>();
            CreateMap<EditProductParfumeDTO, ProductEntity>().ReverseMap();


            CreateMap<CreateParfumePieceDTO, ParfumePiece>().ReverseMap();
            CreateMap<ParfumePieceDTO, ParfumePiece>().ReverseMap();
            CreateMap<EditParfumePieceDTO, ParfumePiece>().ReverseMap();

            CreateMap<CreateParfumeDTO, Parfume>().ReverseMap();
            CreateMap<ParfumeDTO, Parfume>().ReverseMap();

            CreateMap<EditUserDTO, UserEntity>()
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture != null ? Path.GetRandomFileName() : null));
            CreateMap<UserEntity, GetUserDTO>();
        }
    }
}
