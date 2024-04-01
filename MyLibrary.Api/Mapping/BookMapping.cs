using MyLibrary.Api.Dtos;
using MyLibrary.Api.Entities;

namespace MyLibrary.Api.Mapping;

public static class BookMapping
{
    public static Book ToEntity(this CreateBookDto newBook) {
        var genre = MapGenre(newBook.Genre);

        return new Book() {
                genre = genre,
                publication_year = newBook.PublicationYear,
                title = newBook.Title,
                type = newBook.Type,
                author_id = newBook.AuthorId,                
            };
    }

     public static BookDto ToDto(this Book book) {
        var authorFullName = $"{book.Author?.first_name} {book.Author?.last_name}";
        

        return new (
            book.book_id,
            book.title,
            book.publication_year,
            book.type,
            book.genre,
            authorFullName
        );
    }

    public static string MapGenre(string genre)
    {
        var mappedGenre = new Dictionary<string, string>
        {
            { "sci-fi", "Scifi" },
            { "science fiction", "Scifi" },
            { "sci fi", "Scifi" }
        };
        
        string lowerGenre = genre.ToLower();
        
        if (mappedGenre.ContainsKey(lowerGenre))
        {
            return mappedGenre[lowerGenre];
        }

        return genre;
    }
}
