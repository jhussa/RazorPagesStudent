using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesStudent.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesStudent.Pages_Students
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesStudentContext _context;

        public IndexModel(RazorPagesStudentContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }
         [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Addresss { get; set; }
        [BindProperty(SupportsGet = true)]
        public string StudentAddress { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of Addresss.
            IQueryable<string> AddressQuery = from m in _context.Student
                                            orderby m.Address
                                            select m.Address;

            var Students = from m in _context.Student
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Students = Students.Where(s => s.FirstName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(StudentAddress))
            {
                Students = Students.Where(x => x.Address == StudentAddress);
            }
            Addresss = new SelectList(await AddressQuery.Distinct().ToListAsync());
            Student = await Students.ToListAsync();
        }
    }
}