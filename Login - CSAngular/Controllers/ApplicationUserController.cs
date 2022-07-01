using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Login___CSAngular.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Login___CSAngular.Controllers;


[ApiController]
[Route("[controller]")]
public class ApplicationUserController : ControllerBase
{
    
    private UserManager<ApplicationUser> _userManager;
    private SignInManager<ApplicationUser> _singInManager;
    private readonly ApplicationSettings _appSettings;

    public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
    {
        _userManager = userManager;
        _singInManager = signInManager;
        _appSettings = appSettings.Value;
    }

    [HttpPost]
    [Route("/api/Register")]
    //POST : /api/ApplicationUser/Register
    public async Task<IActionResult> PostApplicationUser(UserModel model)
    {
        var applicationUser = new ApplicationUser() {
            FullName = model.Name,
            Email = model.Email,
            Cpf = model.Cpf,
            PhoneNumber = model.Phone,
            Adrress = model.Address,
            UserName = model.Email.Substring(0, model.Email.IndexOf('@'))
        };

        try
        {
            var result = await _userManager.CreateAsync(applicationUser, model.Password);
            return Ok(result);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    
    [HttpPost]
    [Route("/api/Login")]
    //POST : /api/ApplicationUser/Login
    public async Task<IActionResult> Login(LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserID",user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return Ok(new { token });
        }
        return BadRequest(new {message = "Username or password is incorrect."} );
    }
}