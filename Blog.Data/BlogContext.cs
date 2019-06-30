using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogConnection")
        {
        }

        public DbSet<Entity.BlogDataModel> Blog { get; set; }
        public DbSet<Entity.ImageDataModel> Image { get; set; }

        public void Commit()
        {
            SaveChanges();
        }
    }
}