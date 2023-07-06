using Microsoft.AspNetCore.Mvc;

namespace BookReservationSystem.API.Controllers
{
    /// <summary>
    /// If your API controllers will use a consistent route convention and the [ApiController] attribute (they should)
    /// then it's a good idea to define and use a common base controller class like this one.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ApiControllerBase : Controller
    {
    }
}
