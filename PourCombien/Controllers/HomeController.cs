using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PourCombien.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PourCombien.Database;

namespace PourCombien.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PourCombienContext Context;

        public HomeController(ILogger<HomeController> logger, PourCombienContext ctx)
        {
            _logger = logger;
            Context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Proposition(string proposition)
        {
            Defi defi = new Defi
            {
                Question = proposition
            };
            Context.Defis.Add(defi);
            Context.SaveChanges();
            return (RedirectToAction("Afficher", new
            {
                id = defi.Id
            }));
        }

        [HttpGet("{id}/")]
        public IActionResult Afficher(Guid id)
        {
            Defi defi = Context.Defis.FirstOrDefault(i => i.Id == id);

            return (View(defi));
        }

        [HttpPost("{id}/")]
        public IActionResult SetMax(Guid id, int number)
        {
            Defi defi = Context.Defis.FirstOrDefault(i => i.Id == id);

            defi.Max = number;
            Context.Defis.Update(defi);
            Context.SaveChanges();

            return (RedirectToAction("Afficher", new
            {
                id
            }));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("{id}/choix")]
        public IActionResult SetChoix(Guid id, int choix)
        {
            Defi defi = Context.Defis.FirstOrDefault(i => i.Id == id);

            if (defi.Choix1 == 0)
            {
                defi.Choix1 = choix;
                Context.Defis.Update(defi);
                Context.SaveChanges();
            }
            else
            {
                defi.Choix2 = choix;
                Context.Defis.Update(defi);
                Context.SaveChanges();

                return (RedirectToAction("Result", new
                {
                    id
                }));
            }

            return (RedirectToAction("Afficher", new
            {
                id
            }));
        }

        [HttpGet("{id}/result")]
        public IActionResult Result(Guid id)
        {
            Defi defi = Context.Defis.FirstOrDefault(i => i.Id == id);
            return (View(defi));
        }
    }
}
