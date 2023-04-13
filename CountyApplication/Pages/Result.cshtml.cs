using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CountyApplication.Pages
{
    public class Result : PageModel
    {
        private readonly ILogger<Result> _logger;

        public Result(ILogger<Result> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}