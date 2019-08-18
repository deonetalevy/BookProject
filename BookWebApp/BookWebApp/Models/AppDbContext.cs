using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //Pass in dbcontextoptions through constructor to the base type
        {

        }

        //Specifies which types need to be in database. 
        public DbSet<Book> Books { get; set; } //Book type will be stored in Books table in database
    }
}
