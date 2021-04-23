using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoListWebApp.Data;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Pages.ToDo
{
    public class EditModel : PageModel
    {
        private readonly ToDoListWebApp.Data.ApplicationDbContext _context;

        public EditModel(ToDoListWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDOList ToDOList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDOList = await _context.ToDOLists.FirstOrDefaultAsync(m => m.ID == id);

            if (ToDOList == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDOList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDOListExists(ToDOList.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDOListExists(int id)
        {
            return _context.ToDOLists.Any(e => e.ID == id);
        }
    }
}
