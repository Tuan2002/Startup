using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Startup.Data;

namespace Startup.Controllers
{
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly StartupDBContext _context;

        public PostController(ILogger<PostController> logger, StartupDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id}")]
        public IActionResult PostDetail(string id)
        {
            try
            {
                if (id == null)
                    return NotFound();
                var postDetail = (
                    from post in _context.Post
                    where post.IsActive == true && post.Status == 1 && post.PostID == Int32.Parse(id)
                    select post
                ).FirstOrDefault();
                if (postDetail == null)
                    return NotFound();
                return View(postDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error!");
                return StatusCode(500);
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}