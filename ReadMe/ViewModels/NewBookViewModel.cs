using ReadMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadMe.ViewModels
{
    public class NewBookViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Book Book { get; set; }


    }
}