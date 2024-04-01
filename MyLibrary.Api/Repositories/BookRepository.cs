using Microsoft.EntityFrameworkCore;
using MyLibrary.Api.Data;
using MyLibrary.Api.Dtos;
using MyLibrary.Api.Entities;
using MyLibrary.Api.Mapping;

namespace MyLibrary.Api.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    private LibraryDBContext _libraDbContext;
    public BookRepository(LibraryDBContext dbContext)
        :base(dbContext)
    {
        _libraDbContext = dbContext;
    }
    public async Task<IEnumerable<BookDto>> GetBooks(int pageSize, int pageNumber)
    {
         return await _libraDbContext.Books
                        .Include(x => x.Author)                        
                        .Select(book => book.ToDto())
                        .Skip((pageNumber -1) * pageSize)
                        .Take(pageSize)
                        .AsNoTracking().ToListAsync();
    }

    public async Task<BookDto?> GetBookById(int bookId)
    {
        var book = await _libraDbContext.Books.Include(book => book.Author).SingleOrDefaultAsync(book => book.book_id == bookId);
        return book?.ToDto();
    }

}
