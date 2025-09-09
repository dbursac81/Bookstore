using Bookstore.Data.Context;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Bookstore.Test.Mocks;

namespace Bookstore.Application.Services;

public class BookImportService : BackgroundService
{
    private readonly IServiceProvider _sp;
    private readonly ILogger<BookImportService> _logger;

    public BookImportService(IServiceProvider sp, ILogger<BookImportService> logger)
    {
        _sp = sp;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await DoImport(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Import failed");
            }
            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }

    private async Task DoImport(CancellationToken ct)
    {
        using var scope = _sp.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BookstoreContext>();

        // simulating the third-party API: returning large list
        var imported = MockThirdPartyApiSimulator.GetLargeBookBatch(100_000);

        // normalizing and setting to manageable sizes
        const int batchSize = 1000;
        var batch = imported.Select((b, i) => (b, i)).GroupBy(x => x.i / batchSize).Select(g => g.Select(x => x.b).ToList());

        foreach (var item in batch)
        {
            var normalized = item.Select(b => BookstoreContext.NormalizeTitle(b.Title)).ToList();
                        
            var existingTitles = await db.Books
                .AsNoTracking()
                .Where(b => normalized.Contains(b.NormalizedTitle))
                .Select(b => b.NormalizedTitle)
                .ToListAsync(ct);

            var toInsert = item.Where(b => !existingTitles.Contains(BookstoreContext.NormalizeTitle(b.Title)))
                                .ToList();

            foreach (var imp in toInsert)
            {
                //setting book data
                var bookEntity = new Book
                {
                    Title = imp.Title,
                    Price = imp.Price,
                    Authors = imp.Authors.Select(a => new Author { Name = a.Name, YearOfBirth = a.YearOfBirth }).ToList(),
                    Genres = imp.Genres.Select(g => new Genre { Name = g.Name }).ToList(),
                    Reviews = imp.Reviews.Select(r => new Review { Rating = r.Rating, Text = r.Text }).ToList()
                };
                db.Books.Add(bookEntity);
            }

            await db.SaveChangesAsync(ct);
        }
    }
}
