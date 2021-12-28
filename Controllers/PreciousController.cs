using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowThings.Controllers
{
    public class PreciousController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
