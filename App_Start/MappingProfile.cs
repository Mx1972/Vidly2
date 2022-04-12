﻿using AutoMapper;
using Vidly2.DTOs;
using Vidly2.Models;

namespace Vidly2.App_Start
{
    public class MappingProfile: Profile
    {   public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();    
        }        
    }
}