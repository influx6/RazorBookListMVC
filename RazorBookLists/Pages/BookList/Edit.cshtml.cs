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
    public class EditModel : PageModel
    {
        private DBContext _db;

        [TempData]
        public string Message { get; set; }

        public EditModel(DBContext db)
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

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Books.Update(Book);
            await _db.SaveChangesAsync();
            Message = "Book updated successfully!";
            return RedirectToPage("Index");
        }
    }
}