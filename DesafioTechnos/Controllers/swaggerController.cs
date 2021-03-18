using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTechnos.Controllers
{
    public class swaggerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
