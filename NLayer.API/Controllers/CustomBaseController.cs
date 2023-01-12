using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/[controller]/[action]")]olsaydı endpointlere metodun isminin yazılması gerekirdi
    [ApiController]
    public class CustomBaseController : ControllerBase
    { 
        [NonAction]//bu metod bir endpoint değildir bunu belirtmek için kullanılır
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
