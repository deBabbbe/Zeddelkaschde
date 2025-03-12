using Core.DataTypes;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccessLayer;

public class ZeddelkaschdeContext : DbContext
{
    public DbSet<Zeddel> ZeddelList { get; set; }

    public DbSet<Kaschde> KaschdeList { get; set; }

    public string DbPath { get; }

    public ZeddelkaschdeContext()
    {
        DbPath = @".\zeddelkaschde.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
}
