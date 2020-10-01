using System.Collections.Generic;
using MealApp.Models;

namespace MealApp.Data
{
    public interface IMealRepo 
    {
        bool SaveChanges();
        IEnumerable<Meal> GetAllMeals(); //will get all meals
        Meal GetMealById(int id); //will get a single meal
        void CreateMeal(Meal cmd);
        void UpdateMeal(Meal cmd);
        void DeleteMeal(Meal cmd);
    }
}