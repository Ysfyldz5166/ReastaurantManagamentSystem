using AutoMapper;
using Cafe.BusinessLogic.Command.Advertisement;
using Cafe.BusinessLogic.Command;
using Cafe.Entities.Dto;
using Cafe.Entities.Entities;
using Cafe.BusinessLogic.Command.Users.Command;
using Cafe.BusinessLogic.Command.Categories.Command;

namespace CafeApi.Mapping
{
    public class FrontProfile : Profile
    {
        public FrontProfile()
        {
            // Advertisement mappings
            CreateMap<Adverisement, AdvertisemetDto>().ReverseMap();
            CreateMap<AddAdvertisementCommand, Adverisement>();
            CreateMap<UpdateAdvertisementCommand, Adverisement>();
            CreateMap<DeleteAdvertisementCommand, Adverisement>();

            // User mappings
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AddUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<DeleteUserCommand, User>();

            //Food mappings
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<AddFoodCommand, Food>().ReverseMap();
            CreateMap<UpdateFoodCommand, Food>().ReverseMap();
            CreateMap<DeleteFoodCommand, Food>().ReverseMap();


            //Category mappings
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AddCategoryCommand, Category>();
            CreateMap<DeleteCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}
