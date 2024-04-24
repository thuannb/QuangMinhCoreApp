using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KBStarCoreApp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	public class BaseController : ControllerBase
	{
	}
}
