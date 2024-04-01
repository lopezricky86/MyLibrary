using Microsoft.EntityFrameworkCore;
using MyLibrary.Api.Data;
using MyLibrary.Api.Dtos;
using MyLibrary.Api.Mapping;
using MyLibrary.Api.Repositories;

namespace MyLibrary.Api.Endpoints;

public static class MapAuthorsEnpoints
{
    const string GetAuthorEndpointName = "GetAuthor";

    public static RouteGroupBuilder AuthorsEndpoints(this WebApplication app){
        var group = app.MapGroup("authors")
                        .WithParameterValidation()
                        .RequireAuthorization(x => x.RequireRole(["user"]));

        group.MapGet("/", async (IUnitOfWork unitOfWork) => {
            var authorDto = await unitOfWork.Authors.GetAuthors();
            return authorDto.Count() > 0 ? 
                    Results.Ok(authorDto) :
                    Results.NotFound();
        });

        // GET book by id
        group.MapGet("/{id}", async (IUnitOfWork unitOfWork, int id) => {
            var author = await unitOfWork.Authors.GetAuthorById(id);
                            
            if (author is not null)
            {                
                return Results.Ok(author);
            }
            else
            {                
                return Results.NotFound();
            }            
        }).WithName(GetAuthorEndpointName);

        // Create author
        group.MapPost("/", async (IUnitOfWork unitOfWork, CreateAuthorDto newAuthor) => {
            var author = newAuthor.ToEntity();            
            await unitOfWork.Authors.Add(author);
            await unitOfWork.Complete();

            var createdAuthor = await unitOfWork.Authors.GetAuthorById(author.author_id);

            return Results.CreatedAtRoute(GetAuthorEndpointName, new {id = author.author_id}, createdAuthor);
        }).RequireAuthorization(x => x.RequireRole(["admin"]));


        return group;
    }

}
