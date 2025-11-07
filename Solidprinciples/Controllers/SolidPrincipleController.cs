using Microsoft.AspNetCore.Mvc;
using SolidpricipaleModel.Solidprinciplemodel;

namespace Solidprinciples.Controllers
{
    public class SolidPrincipleController : Controller
    {
        [HttpGet]
        [Route("Logincontrol")]

        public IActionResult LoginMethod(Solidmodel LoginInputModel)
        {
            var result = login.Login(LoginInputModel);

            return Ok(result);
        }
    }
}
