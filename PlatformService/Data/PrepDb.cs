namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation( IApplicationBuilder app)
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }


        }

        private static void SeedData( AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Cargando Data...");

                context.Platforms.AddRange(
                    new Models.Platform() { Name="Dot net", SecondName="aaa", Publisher="Microsoft", Cost="free"},
                    new Models.Platform() { Name = "Java",  SecondName = "bbb", Publisher = "Oracle", Cost = "free" },
                    new Models.Platform() { Name = "Angular",  SecondName = "ccc", Publisher = "Sun", Cost = "free" },
                    new Models.Platform() { Name = "SQL Server",  SecondName = "ddd", Publisher = "Microsoft", Cost = "free" },
                    new Models.Platform() { Name = "Dot net", SecondName = "eee", Publisher = "Microsoft", Cost = "free" },
                    new Models.Platform() { Name = "Kubernate", SecondName = "fff", Publisher = "Cloud Native", Cost = "free" },
                    new Models.Platform() { Name = "Jc net", SecondName = "ggg",  Publisher = "DevCode", Cost = "free" }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Ya hay datos...");
            }

        }

    }
}
