namespace my_library.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Models.Book()
                    {
                        Title = "Title1",
                        Description = "this is book1",
                        Author = "Udesh",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        DateAdded = DateTime.Now,
                        Genre = "Drama",
                        Rate = 8,
                        CoverUrl = "gjhbhjbjt7867^$^897"
                    },
                    new Models.Book()
                    {
                        Title = "Title2",
                        Description = "this is book2.....",
                        Author = "John",
                        IsRead = false,
                        DateAdded = DateTime.Now,
                        Genre = "Horror",
                        CoverUrl = "https....."
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
