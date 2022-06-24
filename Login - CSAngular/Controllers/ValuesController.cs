using Login___CSAngular.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Login___CSAngular.Controllers;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
   public ValuesController(AuthenticationContext context)
   {
      
   }
}