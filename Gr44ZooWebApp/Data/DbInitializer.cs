using Gr44ZooWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Gr44ZooWebApp.Data
{
    public class DbInitializer
    {
        internal static void Initialize(ZooDbContext context)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();

            if (context.Animals.Any())// Seed check
            {
                return;
            }

            // seed in the following into the DB

            context.Animals.Add(new Animal() { AnimalName= "Cow",Species="Mammal", CalledByName="Second Fräz", Quantity=1});//
        }
    }
}
