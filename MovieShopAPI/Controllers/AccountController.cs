using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserRepository _userRepository;
        public AccountController(IAccountService accountService, IUserRepository userRepository)
        {
            _accountService = accountService;
            _userRepository = userRepository;

        }

        [HttpPost]
        [Route("register")]
        // api/account/register
        public async Task<IActionResult> Register( UserRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                //http status returned should be 400 (bad request)
                return BadRequest(ModelState);
            }
            var user = await _accountService.RegisterUser(model);

            return Ok(user);
            
        }

        [HttpPost]
        [Route("login")]
        // api/account/login
        public async Task<IActionResult> Login( string email, string password)
        {
            var user = await _accountService.LoginUser(email, password);
            if(user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("check-email")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            var dbUser = await _userRepository.GetUserByEmail(email);
            if(dbUser == null)
            {
                return NotFound(new { errorMessage = "email not found in DB"});
            }
            return Ok(dbUser);
        }
    }
}
