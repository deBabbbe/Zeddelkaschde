using Core.DataTypes;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccessLayer;

public class ZeddelkaschdeContext : DbContext
{
    public DbSet<Zeddel> ZeddelList { get; set; }
    public DbSet<Kaschde> KaschdeList { get; set; }
    public DbSet<ZeddelContent> ZeddelContents { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Topic> Topics { get; set; }

    public string DbPath { get; }

    public ZeddelkaschdeContext()
    {
        DbPath = @".\zeddelkaschde.db";
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Zeddel>()
            .HasOne(z => z.Question)
            .WithMany()
            .HasForeignKey(z => z.Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Zeddel>()
            .HasOne(z => z.Answer)
            .WithMany()
            .HasForeignKey(z => z.Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Attachment>()
            .HasOne(a => a.ZeddelContent)
            .WithMany(z => z.Attachments)
            .HasForeignKey(a => a.ZeddelContentId);

        base.OnModelCreating(modelBuilder);
    }

}
