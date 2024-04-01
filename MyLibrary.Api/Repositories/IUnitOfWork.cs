namespace MyLibrary.Api.Repositories;

public interface IUnitOfWork : IDisposable
{
    IBookRepository Books { get; }
    IAuthorRepository Authors { get; }
    Task<int> Complete();
}
