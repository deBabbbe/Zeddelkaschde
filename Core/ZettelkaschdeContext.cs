using Microsoft.EntityFrameworkCore;

namespace Core;

public class ZettelkaschdeContext : DbContext
{
    public DbSet<Zeddel> ZeddelList { get; set; }

    public DbSet<Kaschde> KaschdeList { get; set; }

    public string DbPath { get; }

    public ZettelkaschdeContext()
    {
        DbPath = @".\zeddelkaschde.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
}
