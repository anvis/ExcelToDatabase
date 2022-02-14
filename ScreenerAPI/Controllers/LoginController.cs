using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ScreenerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
  {
    private SignInManager<IdentityUser> signInManager; 
    public LoginController(SignInManager<IdentityUser> signIn)
    {
      signInManager = signIn;
    }

    [HttpGet]
    [Route("GetProviders")]
    public async Task<IActionResult> GetProviders()
    {
      //SignInManager<AppUser> sign = new SignInManager<AppUser>;
       var x = await signInManager.GetExternalLoginInfoAsync();
      return null;
    }
  }
}

class AppUser
{ 

}