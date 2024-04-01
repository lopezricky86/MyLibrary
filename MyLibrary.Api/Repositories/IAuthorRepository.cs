using MyLibrary.Api.Dtos;
using MyLibrary.Api.Entities;

namespace MyLibrary.Api.Repositories;

public interface IAuthorRepository: IRepository<Author>
{
    Task<IEnumerable<AuthorDto>> GetAuthors();
    Task<AuthorDto?> GetAuthorById(int authorId);
}
