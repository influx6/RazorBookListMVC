using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorBookLists.Models;

namespace RazorBookLists.Pages.BookList
{
    public class DetailsModel : PageModel
    {
        private DBContext _db;

        public DetailsModel(DBContext db)
        {
            this._db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Book = await _db.Books.FirstOrDefaultAsync((m) => m.Id == id);
            return Page();
        }

    }
}