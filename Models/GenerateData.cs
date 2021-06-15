using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace UserDirectory.Models
{
    public class GenerateData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcUserContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcUserContext>>()))
            {
                // Look for any users.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        Name = "Bob",
                        Surname = "Saget",
                        Email = "bobsaget@gmail.com",
                        Phone = "121-456-7890",
                        BirthDate = DateTime.Parse("1958-3-12"),
                        Location = "USA"
                    },

                    new User
                    {
                        Name = "Alex",
                        Surname = "DeSouza",
                        Email = "alex@gmail.com",
                        Phone = "122-456-7890",
                        BirthDate = DateTime.Parse("1958-3-12"),
                        Location = "BR"
                    },

                    new User
                    {
                        Name = "David",
                        Surname = "Luis",
                        Email = "david@gmail.com",
                        Phone = "123-456-7890",
                        BirthDate = DateTime.Parse("1958-3-12"),
                        Location = "BR"
                    },

                    new User
                    {
                        Name = "Maroon",
                        Surname = "Five",
                        Email = "maroon@gmail.com",
                        Phone = "124-456-7890",
                        BirthDate = DateTime.Parse("1958-3-12"),
                        Location = "USA"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}