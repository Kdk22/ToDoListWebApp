using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoListWebApp.Data;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Pages.ToDo
{
    public class CreateModel : PageModel
    {
        private readonly ToDoListWebApp.Data.ApplicationDbContext _context;

        public CreateModel(ToDoListWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDOList ToDOList { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDOLists.Add(ToDOList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
