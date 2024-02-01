using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
	public class MapController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
