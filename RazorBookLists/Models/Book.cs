using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorBookLists.Models
{
    public class Book
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public int Availability { get; set; }

        [Required]
        public double Price { get; set; }

        public Book()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
