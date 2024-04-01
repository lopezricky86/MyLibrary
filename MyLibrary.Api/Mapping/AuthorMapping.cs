using MyLibrary.Api.Dtos;
using MyLibrary.Api.Entities;

namespace MyLibrary.Api.Mapping;

public static class AuthorMapping
{
    public static AuthorDto ToDto(this Author author)
    {
        var authorFullName = $"{author.first_name} {author.last_name}";
        int age = DateTime.Today.Year - author.date_of_birth.Year;

        return new(
            author.author_id,
            authorFullName,
            author.date_of_birth,
            age
        );
    }

    public static Author ToEntity(this CreateAuthorDto newAuthor) {
        
        return new Author() {
            first_name = newAuthor.FirstName,
            last_name = newAuthor.LastName,
            gender = newAuthor.Gender,
            date_of_birth = newAuthor.DateOfBirth
        };
    }
}