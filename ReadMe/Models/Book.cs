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

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Wpisz tytuł książki")]
        public string Name { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Wpisz autora książki")]
        public string Author { get; set; }

        [Display(Name = "Popularność")]
        [Required(ErrorMessage = "Wpisz popularność książki")]
        public int Popularity { get; set; }
       
        public Genre Genre { get; set; }

        
        [Display(Name = "Gatunek")]
        [Required(ErrorMessage = "Wybierz gatunek książki")]
        public byte GenreId { get; set; }

        public BookType BookType { get; set; }

        [Display(Name = "Rodzaj książki")]
        [Required(ErrorMessage = "Wpisz rodzaj książki")]       
        public byte BookTypeId { get; set; }


    }
}