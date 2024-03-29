namespace MyLibrary.Api.Dtos;

public record class CreateBookDto(    
    string Title,
    int PublicationYear,
    string Type,
    string Genre
);
