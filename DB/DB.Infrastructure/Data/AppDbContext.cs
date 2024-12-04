using DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SupportService.Infrastructure.Data;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<CarBrand> CarBrands { get; set; }
    public DbSet<CarClass> CarClasses { get; set; }
    public DbSet<CarBodyType> CarBodyTypes { get; set; }
}
