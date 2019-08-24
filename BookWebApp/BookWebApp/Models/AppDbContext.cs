using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookWebApp.Models
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        //Pass in dbcontextoptions through constructor to the base type
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Specifies which types need to be in database. 
        public DbSet<Book> Books { get; set; } //Book type will be stored in Books table in database
    }
}
