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
    public class IndexModel : PageModel
    {
        private readonly ToDoListWebApp.Data.ApplicationDbContext _context;

        public IndexModel(ToDoListWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToDOList> ToDOList { get;set; }

        public async Task OnGetAsync()
        {
            ToDOList = await _context.ToDOLists.ToListAsync();
        }
    }
}
