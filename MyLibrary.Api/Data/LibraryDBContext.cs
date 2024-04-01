using Microsoft.EntityFrameworkCore;
using MyLibrary.Api.Entities;

namespace MyLibrary.Api.Data;

public class LibraryDBContext(DbContextOptions<LibraryDBContext> options): DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
}
