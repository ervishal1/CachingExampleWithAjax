using CachingExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Rotativa.AspNetCore;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CachingExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache MemoryCache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            MemoryCache = memoryCache;
        }

        public IActionResult Index(bool? val)
        {
            DateTime CurrentTime;
            bool value = MemoryCache.TryGetValue("CachedTime", out CurrentTime);
            if (!value)
            {
                CurrentTime = DateTime.Now;
                var cacheEntryOptions = new MemoryCacheEntryOptions().
                    SetSlidingExpiration(TimeSpan.FromSeconds(30));
                MemoryCache.Set("CachedTime",CurrentTime,cacheEntryOptions);
            }
            if (val == true)
            {
                return new ViewAsPdf(CurrentTime);
            }
            return View(CurrentTime);
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
    }
}
