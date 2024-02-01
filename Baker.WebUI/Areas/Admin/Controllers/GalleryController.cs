using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
	public class GalleryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
