using BorrowThings.Data;
using BorrowThings.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowThings.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //To have all the items in the Item database displaysed on the views browser
            IEnumerable<item> objList = _db.Items;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }


        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
