using dotnet_mvc_expense_tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_mvc_expense_tracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Budget> Budgets { get; set; }
    }
}
