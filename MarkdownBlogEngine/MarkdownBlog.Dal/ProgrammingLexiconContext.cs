using Microsoft.EntityFrameworkCore;
using ProgrammingLexicon.Dal.Models;

namespace ProgrammingLexicon.Dal
{
    public class ProgrammingLexiconContext : DbContext
    {
        public ProgrammingLexiconContext(DbContextOptions<ProgrammingLexiconContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().ToTable(nameof(Article));
        }
    }
}
