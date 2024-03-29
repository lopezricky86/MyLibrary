namespace MyLibrary.Api.Dtos;

public record class BookDto(
    int BookId,
    string Title,
    int PublicationYear,
    string Type,
    string Genre
);
