using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet]
        [Route("check-email")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            var dbUser = await _userRepository.GetUserByEmail(email);
            if (dbUser == null)
            {
                return NotFound(new { errorMessage = "email not found in DB" });
            }
            return Ok(dbUser);
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
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            var user = await _accountService.LoginUser(model.Email, model.Password);
            // return a token...
            // JWT Json Web Token
            // iOS, Android app oe Web APP (Angular or React)

            return Ok(user);
        }


        private string GenerateJwtToken(UserLoginResponseModel user)
        {
            // create claims so that we have those in the payload

            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new("Language", "English")
        };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            // specify the secret KEY
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyTopSecretKeyForJWTTokenGenerationVersion1sfhbksjbfkjsdfjkdsnb"));

            // specify the algorithm
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // how long the token is valid
            var tokenExpiration = DateTime.UtcNow.AddHours(2);

            var tokenHandler = new JwtSecurityTokenHandler();

            // create an object for above details for the token

            var tokenDetails = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = tokenExpiration,
                SigningCredentials = credentials,
                Issuer = "MovieShop, Inc",
                Audience = "MovieShop Users"
            };

            var encodedJwt = tokenHandler.CreateToken(tokenDetails);

            return tokenHandler.WriteToken(encodedJwt);
        }


    }
}
