using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Models.DTOs;
using Blog.Models;

namespace Server.Models.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
		{			
			CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
		}
    }
}