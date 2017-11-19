using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadMe.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz imię")]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; } // it will treat it as foreign key
    }
}