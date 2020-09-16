namespace ForumSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IPostsService postsService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            //TODO: read the post
            return this.View(id);
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var postId = await this.postsService.CreateAsync(input.Title, input.Content, input.CategoryId, user.Id);

            //redirect..
            return this.RedirectToAction(nameof(ById), new { id = postId });
        }
    }
}
