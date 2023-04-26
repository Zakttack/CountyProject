using CountyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CountyApplication.Pages
{
    public class Test : PageModel
    {
        private readonly ILogger<Test> _logger;

        public Test(ILogger<Test> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost(IReadOnlyList<TestEntry> testEntries)
        {
            return Service.ValidState ? Redirect("Result") : Redirect("Index");
        }
    }
}