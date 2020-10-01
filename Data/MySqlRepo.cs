using System;
using System.Collections.Generic;
using System.Linq;
using MealApp.Models;

namespace MealApp.Data
{
    public class MySqlRepo : IMealRepo
    {
        private readonly MealContext _context;

        public MySqlRepo(MealContext context)
        {
            _context = context;
        }

        public void CreateMeal(Meal cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Meals.Add(cmd);
        }

        public void DeleteMeal(Meal cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Meals.Remove(cmd);
            
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            return _context.Meals.ToList();
        }

        public Meal GetMealById(int id)
        {
            return _context.Meals.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }

        public void UpdateMeal(Meal cmd)
        {
            //nothing
        }
    }
} 