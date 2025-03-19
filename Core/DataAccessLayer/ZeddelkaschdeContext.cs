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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Zeddel>()
            .HasOne(zeddel => zeddel.Question)
            .WithMany()
            .HasForeignKey(zeddel => zeddel.Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Zeddel>()
            .HasOne(zeddel => zeddel.Answer)
            .WithMany()
            .HasForeignKey(zeddel => zeddel.Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Attachment>()
            .HasOne(attachment => attachment.ZeddelContent)
            .WithMany(zeddelContent => zeddelContent.Attachments)
            .HasForeignKey(attachment => attachment.ZeddelContentId);

        base.OnModelCreating(modelBuilder);
    }

}
