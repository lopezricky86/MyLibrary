namespace MyLibrary.Api.Dtos;

public record class AuthorDto(
    int AuthorId,
    string FullName,    
    DateOnly DateOfBirth,
    int Age
);
