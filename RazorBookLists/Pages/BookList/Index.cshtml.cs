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
    public class IndexModel : PageModel
    {
        private DBContext _db;
        public IEnumerable<Book> Books { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(DBContext db)
        {
            this._db = db;
        }


        public async Task OnGet()
        {
            this.Books = await _db.Books.ToListAsync();
        }
    }
}