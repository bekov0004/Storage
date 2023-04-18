using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

     public DbSet<Expense> Expenses { get; set; }
     public DbSet<Parishe> Parishes { get; set; }

}
