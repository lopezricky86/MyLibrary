namespace MyLibrary.Api.Dtos;

public record class AuthorDto(
    int AuthorId,
    string FullName,
    string Gender,
    DateOnly DateOfBirth
);
