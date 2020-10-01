using AutoMapper;
using MealApp.Dtos;
using MealApp.Models;

namespace MealApp.Profiles
{
    public class MealsProfile : Profile
    {
        public MealsProfile()
        {   //source (Meal) -> target (MealReadDto)
            CreateMap<Meal, MealReadDto>();

            //target (MealReadDto)  -> source (Meal) 
            CreateMap<MealCreateDto, Meal>();

            CreateMap<MealUpdateDto, Meal>();
            CreateMap<Meal, MealUpdateDto>();
        }
    }
}