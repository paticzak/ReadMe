using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadMe.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }

    }
}