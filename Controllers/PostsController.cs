using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Blog.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Post> GetPosts()
        {
            return new List<Post>();
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Post> GetPost(Guid id)
        {
            return new List<Post>();
        }

        [HttpPost]
        [Route("add")]
        public void AddPost(PostDto postModel)
        {

        }

        [HttpPut]
        [Route("update")]
        public void UpdatePost(Guid id)
        {

        }

        [HttpDelete]
        [Route("delete")]
        public void DeletePost(Guid id)
        {

        }
    }
}
