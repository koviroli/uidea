using System;
using UIdea.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace UIdea.Models
{
    public static class SeedDataApplicationUser
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Users.Any())
                    return;

                var defaultAvatar = Path.Combine("wwwroot", "images", "ideaavatar_default_lightbulb_25_25.jpg");

                FileStream image = System.IO.File.OpenRead(@defaultAvatar);
                
                for (int i = 0; i < 100; ++i)
                {
                    var user = new ApplicationUser()
                    {
                        UserName = string.Format("user{0}",i),
                        Email = string.Format("user{0}@hotmail.com",i),
                        PasswordHash = "asddsa123",
                        AvatarImage = new byte[image.Length]
                    };
                    image.Read(user.AvatarImage, 0, (int)image.Length);
                    context.Add(user);
                }
                context.SaveChanges();
            }
        }
    }
}
