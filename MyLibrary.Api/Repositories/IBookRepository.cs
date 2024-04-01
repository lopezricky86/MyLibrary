using MyLibrary.Api.Dtos;
using MyLibrary.Api.Entities;

namespace MyLibrary.Api.Repositories;

public interface IBookRepository: IRepository<Book>
{
    Task<IEnumerable<BookDto>> GetBooks(int pageSize, int pageNumber);
    Task<BookDto?> GetBookById(int bookId);
}
