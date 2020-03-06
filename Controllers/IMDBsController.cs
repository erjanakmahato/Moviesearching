using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Helper.Models;
using MoviesSearch.Data;
using MoviesSearch.Models;

namespace MoviesSearch.Controllers
{
    public class IMDBsController : Controller
    {
        private readonly MoviesSearchContext _context;

        public IMDBsController(MoviesSearchContext context)
        {
            _context = context;
        }

        // GET: IMDBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.IMDB3.ToListAsync());
        }

        // GET: IMDBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iMDB = await _context.IMDB3
                .FirstOrDefaultAsync(m => m.SN == id);
            if (iMDB == null)
            {
                return NotFound();
            }

          

            return View(iMDB);
        }


        // GET: IMDBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IMDBs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Rating,Duration,Type,ReleaseYear,Director,Stars,Descreption,Image")] IMDB3 iMDB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iMDB);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(iMDB);
        }

        // GET: IMDBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iMDB = await _context.IMDB3.FindAsync(id);
            if (iMDB == null)
            {
                return NotFound();
            }
            return View(iMDB);
        }

        // POST: IMDBs/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double id, [Bind("SN,Name,Rating,Duration,Type,ReleaseYear,Director,Stars,Descreption,Image")] IMDB3 iMDB)
        {
            if (id != iMDB.SN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iMDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IMDBExists(iMDB.SN))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(iMDB);
        }

        // GET: IMDBs/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iMDB = await _context.IMDB3
                .FirstOrDefaultAsync(m => m.SN == id);
            if (iMDB == null)
            {
                return NotFound();
            }
            return View(iMDB);
        }

        // POST: IMDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var iMDB = await _context.IMDB3.FindAsync(id);
            _context.IMDB3.Remove(iMDB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IMDBExists(double id)
        {
            return _context.IMDB3.Any(e => e.SN == id);
        }
        public async Task<IActionResult> search(string query, int? pageNumber, string currentFilter,string sortOrder)
        {
           IQueryable<string> genreQuery = from m in _context.IMDB3
                                           orderby m.Type
                                            select m.Type;
            if (query != null)
            {
                pageNumber = 1;
            }
            else
            {
                query = currentFilter;
            }
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = currentFilter;
            var movies = from m in _context.IMDB3
                         select m;
            if (!String.IsNullOrEmpty(query))
            {
                movies = movies.Where(s => s.Name.Contains(query)  || s.Stars.Contains(query) || s.Type.Contains(query));
            }
            int pageSize = 10;
           return View(await PaginatedList<IMDB3>.CreateAsync(movies.AsNoTracking(), pageNumber ?? 1, pageSize));
          
        }

    }
}
