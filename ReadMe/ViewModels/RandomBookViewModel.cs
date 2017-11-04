using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReadMe.Models;

namespace ReadMe.ViewModels
{
    public class RandomBookViewModel
    {
        public Book Book { get; set; }
        public List<User> Users { get; set; }
    }
}