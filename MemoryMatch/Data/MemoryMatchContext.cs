// MemoryGameContext.cs (in the Data folder)
using MemoryMatch.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MemoryGame.Data
{
    public class MemoryGameContext : DbContext
    {
        public MemoryGameContext(DbContextOptions<MemoryGameContext> options) : base(options)
        {
            
        }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasKey(x => x.Id);

            modelBuilder.Entity<Card>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Card>(b =>
            {
                b.ToTable("Cards");
                b.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(1000, 1);
            });


            base.OnModelCreating(modelBuilder);
        }

        public void ClearTable()
        {
            Database.ExecuteSqlRaw("DELETE FROM " +
                "cards");

            Database.ExecuteSqlRaw("DBCC CHECKIDENT ('cards', RESEED, 0);");
        }
    }
}
