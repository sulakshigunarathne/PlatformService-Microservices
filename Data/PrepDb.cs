using PlatfromService.Models;
namespace PlatfromService.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var servicesScope = app.ApplicationServices.CreateScope())
            {
                SeedData(servicesScope.ServiceProvider.GetService<AppDBContext>());
            }
        }

        private static void SeedData(AppDBContext dbContext) 
        {
            if(!dbContext.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data");
                Console.ReadLine();
                dbContext.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" });
                
                dbContext.SaveChanges();       
            }
            else
            {
                Console.WriteLine("--> we already have data");
            }
        }
    }
}
