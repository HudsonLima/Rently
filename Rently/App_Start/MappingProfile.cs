using AutoMapper;
using Rently.Controllers.Api;
using Rently.Dto;
using Rently.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rently.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());


        }
    }
}