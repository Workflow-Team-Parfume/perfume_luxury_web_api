using AutoMapper;
using Core.Dtos;
//using Core.Entities;
using System.Drawing;

namespace Core.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //CreateMap<Ingredient, IngredientDto>().ReverseMap();
            //CreateMap<DescriptionStep, DescriptionStepDto>().ReverseMap();

            //CreateMap<Recipe, RecipeDto>()
            //    .ForMember(x => x.Ingredients, opt => opt.MapFrom(x => x.Ingredients.Select(i => i.Ingredient)));

            //CreateMap<RecipeDto, Recipe>();
        }
    }
}
