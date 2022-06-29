using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Database;
using Blog.Database.Repository;
using Blog.Models;
using Blog.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(ILogger<UsersController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Route("register")]
        public IActionResult RegisterUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _unitOfWork.Users.Create(user);
            _unitOfWork.Save();
            return Ok();
        }

        // [Authorize(Roles = "admin")]
        [Route("getusers")]
        public IActionResult GetUsers()
        {
            return Ok(_unitOfWork.Users.GetAll());
        }

        [Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Authorize(Roles = "admin")]
        [Route("getrole")]
        public IActionResult GetRole()
        {
            return Ok("Ваша роль: администратор");
        }

    }
}