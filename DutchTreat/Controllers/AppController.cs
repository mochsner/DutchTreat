using DutchTreat.Data;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly DutchContext _ctx;

        public AppController(IMailService mailService, DutchRepository _ctx)
        {
            _mailService = mailService;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var results = _ctx.Products.ToList();
            return View();
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("marc@ochsner.me", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail sent!";
                ModelState.Clear();
            }
            else
            {
                //show errors
            }
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            var results = from p in _ctx.Products
                          orderby p.Category
                          select p;

            return View(results.ToList());
        }
    }
}
