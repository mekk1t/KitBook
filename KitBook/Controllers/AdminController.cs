using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KitBook.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult GetActions()
        {
            return View(nameof(GetActions));
        }
    }
}
