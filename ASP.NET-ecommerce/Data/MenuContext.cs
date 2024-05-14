using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>()
                .HasOne(d => d.Dish)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(d => d.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(i => i.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Margheritta", Price = 7.50, ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fohsweetbasil.com%2Ffour-cheese-margarita-pizza%2F&psig=AOvVaw1kQNHQ1k9ZLCcgeUFVHvMN&ust=1715693496736000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCIC3sL7eioYDFQAAAAAdAAAAABAE" }
            );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato Sauce" },
                new Ingredient { Id = 2, Name = "Mozzarella" }
            );
            modelBuilder.Entity<DishIngredient>().HasData(
                 new DishIngredient { DishId = 1, IngredientId = 1 },
                 new DishIngredient { DishId = 1, IngredientId = 2 }
            );
               
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}

