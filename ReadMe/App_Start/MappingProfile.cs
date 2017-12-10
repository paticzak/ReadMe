using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ReadMe.Models;
using ReadMe.Dtos;

namespace ReadMe.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<BookDto, Book>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
        }
    }
}