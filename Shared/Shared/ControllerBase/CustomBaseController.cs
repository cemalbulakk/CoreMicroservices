using Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Shared.ControllerBase;

[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : Microsoft.AspNetCore.Mvc.ControllerBase
{
    public IActionResult CreateActionResultInstance<T>(Response<T> response)
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}