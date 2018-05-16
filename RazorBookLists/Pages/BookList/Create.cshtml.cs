using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBookLists.Models;

namespace RazorBookLists.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private DBContext _db;

        [TempData]
        public string Message { get; set; }

        public CreateModel(DBContext db)
        {
            this._db = db;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Books.Add(Book);
            await _db.SaveChangesAsync();
            Message = "Created successfully";
            return RedirectToPage("Index");
        }
    }
}