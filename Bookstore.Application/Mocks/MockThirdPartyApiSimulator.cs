using Bookstore.Application.Dtos;

namespace Bookstore.Test.Mocks;

public static class MockThirdPartyApiSimulator
{
    private static readonly string[] SampleTitles = new[]
    {
        "Crime and Punishment", "War and Peace", "The Hobbit", "Pride and Prejudice",
        "The Great Gatsby", "Moby Dick", "1984", "To Kill a Mockingbird"
    };

    private static readonly string[] SampleAuthorNames = new[]
    {
        "Fyodor Dostoevsky", "Leo Tolstoy", "J.R.R. Tolkien", "Jane Austen",
        "F. Scott Fitzgerald", "Herman Melville", "George Orwell", "Harper Lee"
    };

    private static readonly string[] SampleGenres = new[]
    {
        "Fiction", "Classic", "Fantasy", "Romance", "Adventure", "Drama"
    };

    private static readonly string[] SampleReviewTexts = new[]
    {
        "Amazing book!", "Highly recommend.", "Not my style.", "Could be better.", "A masterpiece."
    };

    public static List<BookDto> GetLargeBookBatch(int count)
    {
        var books = new List<BookDto>(count);
        var rnd = new Random();

        for (int i = 0; i < count; i++)
        {
            var title = $"{SampleTitles[rnd.Next(SampleTitles.Length)]} #{i + 1}";

            var authors = new List<AuthorDto>
            {
                new AuthorDto
                {
                    Name = SampleAuthorNames[rnd.Next(SampleAuthorNames.Length)],
                    YearOfBirth = rnd.Next(1850, 2000)
                }
            };

            var genres = new List<GenreDto>
            {
                new GenreDto { Name = SampleGenres[rnd.Next(SampleGenres.Length)] }
            };

            var reviews = new List<ReviewDto>();
            for (int r = 0; r < rnd.Next(0, 5); r++) // 0-4 reviews
            {
                reviews.Add(new ReviewDto
                {
                    Rating = rnd.Next(1, 6),
                    Text = SampleReviewTexts[rnd.Next(SampleReviewTexts.Length)]
                });
            }

            books.Add(new BookDto
            {
                Title = title,
                Price = Math.Round((decimal)(rnd.NextDouble() * 100), 2),
                Authors = authors,
                Genres = genres,
                Reviews = reviews
            });
        }

        return books;
    }
}

