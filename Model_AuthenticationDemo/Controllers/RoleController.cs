using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace Model_AuthenticationDemo.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<IdentityUser> UserManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> UserManager)
        {
            this.roleManager = roleManager;
            this.UserManager = UserManager;

        }
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);

        }
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

    }
}
