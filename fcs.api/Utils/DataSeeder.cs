using fcs.api.Data;
using fcs.api.Models;

namespace fcs.api.Utils
{
    public static class DataSeeder
    {
        public static void SeedData(AppDbContext context)
        {
            if (!context.Civilizations.Any())
            {
                context.Civilizations.Add(new Civilization
                {
                    Name = "Atlantis",
                    Population = 1000,
                    CurrentYear = 0,
                    Resources = [
                        new Resource { Name = "Food", Quantity = 500 },
                        new Resource { Name = "Minerals", Quantity = 200 }
                        ],
                    Climate = "Temperate",
                    Culture = "Ancient",
                    Technology = "Bronze Age"
                });
                context.SaveChanges();
            }
        }
    }
}
