using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadMe.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Wpisz tytuł książki")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wpisz autora książki")]
        public string Author { get; set; }
        public int Popularity { get; set; }
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }
        public byte BookTypeId { get; set; }
        public BookTypeDto BookType { get; set; }
    }
}