using CatalogService.Model;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Database
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
