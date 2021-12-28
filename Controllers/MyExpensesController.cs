using BorrowThings.Data;
using BorrowThings.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowThings.Controllers
{
    public class MyExpensesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MyExpensesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //To have all the items in the Item database displaysed on the views browser
            IEnumerable<Expenses> objList = _db.Expense;
            return View(objList);

        }

        public IActionResult Create()
        {
            return View();
        }


        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Expenses obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expense.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }




        // POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expense.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // GET-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expense.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Expense.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expense.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        // POST-UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(Expenses obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expense.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
