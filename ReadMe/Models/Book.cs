using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadMe.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Name { get; set; }

        public string Author { get; set; }
       
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }


    }
}