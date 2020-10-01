using MealApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MealApp.Data
{
    public class MealContext : DbContext
    {
        public MealContext(DbContextOptions<MealContext> opt) : base (opt)
        {
            
        } 

        public DbSet<Meal> Meals { get; set; }
    }
}