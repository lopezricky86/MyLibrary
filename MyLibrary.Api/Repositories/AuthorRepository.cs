using Microsoft.EntityFrameworkCore;
using MyLibrary.Api.Data;
using MyLibrary.Api.Dtos;
using MyLibrary.Api.Entities;
using MyLibrary.Api.Mapping;

namespace MyLibrary.Api.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{

    private LibraryDBContext _libraDbContext;
    public AuthorRepository(LibraryDBContext dbContext)
        :base(dbContext)
    {
        _libraDbContext = dbContext;
    }
    
    public async Task<AuthorDto?> GetAuthorById(int authorId)
    {
        var author = await _libraDbContext.Authors.SingleOrDefaultAsync(x => x.author_id == authorId);
        return author?.ToDto();
    }

    public async Task<IEnumerable<AuthorDto>> GetAuthors()
    {
        return await _libraDbContext.Authors
                        .Select(x => x.ToDto())
                        .AsNoTracking().ToListAsync();
    }
}
