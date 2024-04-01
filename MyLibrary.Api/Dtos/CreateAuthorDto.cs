using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Dtos;

public record class CreateAuthorDto
(
    [Required] string FirstName,
    [Required] string LastName,
    string Gender,
    DateOnly DateOfBirth
);

