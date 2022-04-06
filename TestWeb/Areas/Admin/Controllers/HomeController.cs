using Microsoft.AspNetCore.Mvc;
using TestWeb.Domain.Entities;
using TestWeb.Interfaces.Repositories;

namespace TestWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IRepository<News> _newsRepository;

        public HomeController(IRepository<News> newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            return View(_newsRepository.GetAll());
        }
    }
}
