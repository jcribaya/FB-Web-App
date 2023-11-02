using FB.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FB.Data
{
    public class FB_DBContext : DbContext
    {
        public FB_DBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
