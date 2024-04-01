using MyLibrary.Api.Data;

namespace MyLibrary.Api.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private LibraryDBContext context;        
    public UnitOfWork(LibraryDBContext _context)
    {
        context = _context;
        Books = new BookRepository(context);
        Authors = new AuthorRepository(context);
    }

    public IBookRepository Books
    {
        get;
        private set;
    }

    public IAuthorRepository Authors
    {
        get;
        private set;
    }

    public async Task<int> Complete()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
