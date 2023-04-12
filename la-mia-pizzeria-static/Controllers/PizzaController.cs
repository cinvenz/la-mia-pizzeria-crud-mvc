using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly PizzaContext _context;
        public PizzaController(ILogger<PizzaController> logger, PizzaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var pizze = _context.Pizze.ToArray();

            return View(pizze);
        }

        public IActionResult Detail(int id)
        {
            using var ctx = new PizzaContext();
            var pizze = ctx.Pizze.SingleOrDefault(p => p.Id == id);

            if (pizze is null)
            {
                return View("NotFound", "Post not found.");
                //return NotFound($"Pizza with id {id} not found.");
            }

            return View(pizze);
        }

        public IActionResult Create()
        {
            var pizza = new Pizza
            {
                Image = "https://picsum.photos/200/300"
            };

            return View(pizza);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Pizza pizza)
		{
			if (!ModelState.IsValid)
			{
				return View(pizza);
			}

			using var ctx = new PizzaContext();
            ctx.Pizze.Add(pizza);   
            ctx.SaveChanges();  
            return RedirectToAction("Index");   
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

