using LetMePutSomeAsyncInIt.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LetMePutSomeAsyncInIt.Web.Controllers
{
    [RoutePrefix("Post")]
    public class PostController : Controller
    {
        private IPostRepository _postRepo;

        public PostController(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        // GET: Post
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<ActionResult> Index()
        {
            return View(await _postRepo.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            return View(await _postRepo.GetByID(id));
        }
    }
}