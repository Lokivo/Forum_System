namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<(string Name, string ImageUrl)>
            {
                ("Sport", @"https://icon-library.com/images/sports-app-icon/sports-app-icon-16.jpg"),
                ("News", @"https://opic.bg/images/default/news.png"),
                ("Music", @"https://iconsplace.com/wp-content/uploads/_icons/800080/256/png/music-icon-13-256.png"),
                ("Programming", @"https://icons-for-free.com/iconfiles/png/512/coding+dev+development+programming+tag+icon-1320165734987953368.png"),
                ("Food",@"https://freeiconshop.com/wp-content/uploads/edd/eat-flat-1.png"),
                ("Animals", @"https://b.thumbs.redditmedia.com/kYZCkffvs7uJHLRfXXYwxggon-91MsCHkdFXlaMq3Us.png"),
            };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Description = category.Name,
                    Title = category.Name,
                    ImageURL = category.ImageUrl,
                });
            }
        }
    }
}
