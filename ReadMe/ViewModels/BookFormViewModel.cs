﻿using ReadMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadMe.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<BookType> BookTypes { get; set; }
        public Book Book { get; set; }

        public string Title
         {
             get
             {
                 if (Book != null && Book.Id != 0)
                     return "Edytuj książkę";
 
                 return "Dodaj nową książkę";
             }
         }
    }
}