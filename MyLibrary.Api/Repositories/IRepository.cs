namespace MyLibrary.Api.Repositories;

public interface IRepository<T> where T : class
{        
    Task<bool>  Add(T tEntity);
}