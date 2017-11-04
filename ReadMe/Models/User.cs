rewqusing System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadMe.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }

    }
}