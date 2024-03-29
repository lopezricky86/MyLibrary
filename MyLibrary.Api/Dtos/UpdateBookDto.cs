namespace MyLibrary.Api.Dtos;

public record class UpdateBookDto(
    string Title,
    int PublicationYear,
    string Type,
    string Genre
);
