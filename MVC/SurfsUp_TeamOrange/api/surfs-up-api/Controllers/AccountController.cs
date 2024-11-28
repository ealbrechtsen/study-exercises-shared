using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Data;
using surfs_up_api.Models;
using surfs_up_api.Models.ViewModels;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly CustomerDbContext _context;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, CustomerDbContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            _context = context;
        }

        // Handles POST requests for login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);
            if (result.Succeeded)
            {
                return Ok(new { message = "Login successful" });
            }

            return Unauthorized(new { message = "Forkert brugernavn eller adgangskode" });
        }

        // Handles POST requests for registering a new user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AppUser user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                Address = model.Address,
                ZipCode = model.ZipCode,
                City = model.City
            };

            var result = await userManager.CreateAsync(user, model.Password!);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return Ok(new { message = "User registered successfully" });
            }

            return BadRequest(result.Errors);
        }

        // Handles POST requests for logging out
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok(new { message = "Logged out successfully" });
        }
    }
}
