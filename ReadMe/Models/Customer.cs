﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadMe.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł książki")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }
        public List<Customer> Customers { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; } // navigation property / allows us to navigate from one type to another
     
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } // it will treat it as foreign key


        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}