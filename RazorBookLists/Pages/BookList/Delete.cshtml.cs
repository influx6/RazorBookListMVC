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
    public class DeleteModel : PageModel
    {
        private DBContext _db;

        [TempData]
        public string Message { get; set; }

        public DeleteModel(DBContext db)
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

        public async Task<IActionResult> OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _db.Books.FirstOrDefaultAsync((m) => m.Id == id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            Message = "Succesfully deleted book!";
            return RedirectToPage("Index");
        }
    }
}