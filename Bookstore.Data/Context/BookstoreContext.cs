using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data.Context;

public class BookstoreContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Reviews)
            .WithOne(r => r.Book)
            .HasForeignKey(r => r.BookId);
    }

    public override int SaveChanges()
    {
        NormalizeTitles();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        NormalizeTitles();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void NormalizeTitles()
    {
        foreach (var entry in ChangeTracker.Entries<Book>()
                     .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            var title = entry.Entity.Title ?? "";
            entry.Entity.NormalizedTitle = NormalizeTitle(title);
        }
    }

    public static string NormalizeTitle(string title)
    {
        if (title == null) return null;

        return title.Trim().ToLowerInvariant();
    }
}
