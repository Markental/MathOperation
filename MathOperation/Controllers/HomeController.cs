using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MathOperation.Models;
using MathOperation.Data;

namespace MathOperation.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpGet]
        public IActionResult List()
        {
            var model = _context.Operations.ToList();
            return View("List", model);
        }

        [HttpPost]
        public IActionResult Create(Models.Operation operation)
        {
            operation.Result = Math.Pow(operation.First, operation.Second);

            _context.Operations.Add(operation);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var item = _context.Operations.FirstOrDefault(e => e.Id == id);
            _context.Operations.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
