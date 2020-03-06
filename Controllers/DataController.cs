using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.Models;
using Microsoft.AspNetCore.Mvc;

namespace MoviesSearch.Controllers
{
    public class DataController : Controller
    {
        private readonly DataContext _cc;
        public DataController(DataContext cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            var results = _cc.imdb.ToList();
            return View(results);
        }
    }
}