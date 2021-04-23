using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListWebApp.Data;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Pages.ToDo
{
    public class DetailsModel : PageModel
    {
        private readonly ToDoListWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(ToDoListWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
