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
        [Required(ErrorMessage = "Wpisz tytuł książki")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wpisz autora książki")]
        public string Author { get; set; }
       
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Wybierz gatunek książki")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }


    }
}