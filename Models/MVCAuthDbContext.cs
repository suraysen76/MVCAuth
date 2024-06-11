using Microsoft.EntityFrameworkCore;
using MVCAuth.Models;

public class MVCAuthDbContext : DbContext
{
    public MVCAuthDbContext(DbContextOptions<MVCAuthDbContext> options)
        : base(options)
    {
    }
    public DbSet<LoginModel> Users { get; set; }
    



}