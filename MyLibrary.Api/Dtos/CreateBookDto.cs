using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Dtos;

public record class CreateBookDto(    
    [Required] string Title,
    [Required] int AuthorId,
    [Range(1900, int.MaxValue, ErrorMessage = "PublicationYear is invalid")] int PublicationYear,
    string Type,
    string Genre
);
