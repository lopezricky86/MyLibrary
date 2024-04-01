using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic;
using MyLibrary.Api.Data;
using MyLibrary.Api.Dtos;
using MyLibrary.Api.Entities;
using MyLibrary.Api.Mapping;
using MyLibrary.Api.Repositories;

namespace MyLibrary.Api.Endpoints;

public static class BooksEndpoints
{
    const string GetBookEndpointName = "GetBook";

    public static RouteGroupBuilder MapBooksEnpoints(this WebApplication app){
        var group = app.MapGroup("books")
                        .WithParameterValidation()
                        .RequireAuthorization(x => x.RequireRole(["user"]));

        // GET list of books
        group.MapGet("/", async (IUnitOfWork unitOfWork, int pageNumber = 1, int pageSize = 10) => {
            var booksDto = await unitOfWork.Books.GetBooks(10, 1);
            
            if (booksDto.Count() > 0)
            {                
                return Results.Ok(booksDto);
            }
            else
            {
                return Results.NotFound();
            }
        });

        // GET book by id
        group.MapGet("/{id}", async (IUnitOfWork unitOfWork, int id) => {
            var bookDto = await unitOfWork.Books.GetBookById(id);
            if (bookDto is not null)
            {                
                return Results.Ok(bookDto);
            }
            else
            {                
                return Results.NotFound();
            }            
        }).WithName(GetBookEndpointName);

        // Create book
        group.MapPost("/", async (IUnitOfWork unitOfWork, CreateBookDto newBook) => {
            var book = newBook.ToEntity();
            await unitOfWork.Books.Add(book);
            await unitOfWork.Complete();

            var createdBook = await unitOfWork.Books.GetBookById(book.book_id);

            return Results.CreatedAtRoute(GetBookEndpointName, new {id = book.book_id}, createdBook);
        }).RequireAuthorization(x => x.RequireRole(["admin"]));

        return group;
    }
}
