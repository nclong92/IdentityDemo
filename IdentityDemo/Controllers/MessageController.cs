using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityDemo.Data;
using IdentityDemo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityDemo.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessageController(ApplicationDbContext context)
        {
            this._context = context;
        }
        // GET: /<controller>/
        //[Authorize]
        public IActionResult Index()
        {
            var model = _context.Messages.ToList();
            
            return View(model);
        }

        //[Authorize]
        public IActionResult Create()
        {
            var model = new CreateMessageViewModel()
            {

            };

            return View(model);
        }

        //[HttpPost]
        [Authorize]
        public IActionResult Create(CreateMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = new Message()
                {
                    Text = model.Text
                };

                _context.Add(message);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
