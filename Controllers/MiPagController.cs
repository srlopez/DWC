using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using dwc.Models;
using dwc.Data;

namespace dwc.Controllers
{
    public class MiPagController : Controller
    {
        private readonly FARMACIASContext _context;

        public MiPagController(FARMACIASContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var fARMACIASContext = _context.Farmacias.Include(f => f.IdperiodoNavigation);
            return View(await fARMACIASContext.ToListAsync());
        }

    }
}
