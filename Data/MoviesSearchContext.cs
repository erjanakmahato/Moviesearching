using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Helper.Models;

namespace MoviesSearch.Data
{
    public class MoviesSearchContext : DbContext
    {
        public MoviesSearchContext (DbContextOptions<MoviesSearchContext> options)
            : base(options)
        {
        }

        public DbSet<Helper.Models.IMDB3> IMDB3 { get; set; }
    }
}
