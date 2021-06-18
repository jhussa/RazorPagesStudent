using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using RazorPagesStudent.Data;
using System;
using System.Linq;

namespace RazorPagesStudent.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesStudentContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesStudentContext>>()))
            {
                // Look for any Students.
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }

                context.Student.AddRange(
                    new Student
                    {
                        FirstName = "When Harry Met Sally",
                        LastName = "When Harry Met Sally",
                        RecertifiedDate = DateTime.Parse("1989-2-12"),
                        Address = "Romantic Comedy",
                        TandF = 7.99M,
                        Program = "Coding"
                    },

                    new Student
                    {
                        FirstName = "Ghostbusters ",
                        LastName = "When Harry Met Sally",
                        RecertifiedDate = DateTime.Parse("1984-3-13"),
                        Address = "Comedy",
                        TandF = 8.99M,
                        Program = "Coding"
                    },

                    new Student
                    {
                        FirstName = "Ghostbusters 2",
                        LastName = "When Harry Met Sally",
                        RecertifiedDate = DateTime.Parse("1986-2-23"),
                        Address = "Comedy",
                        TandF = 9.99M,
                        Program = "Coding"
                    },

                    new Student
                    {
                        FirstName = "Rio Bravo",
                        LastName = "When Harry Met Sally",
                        RecertifiedDate = DateTime.Parse("1959-4-15"),
                        Address = "Western",
                        TandF = 3.99M,
                        Program = "Coding"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}