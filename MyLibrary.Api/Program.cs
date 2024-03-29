using MyLibrary.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<BookDto> books = [
    new (1, "The Notebook", 2021, "Hardbound", "Love Story"),
    new (2, "Twilight", 2020, "Hardbound", "Fiction")
];

const string GetBookEndpointName = "GetBook";

// GET list of books
app.MapGet("books", () => books);

// GET book by id
app.MapGet("books/{id}", (int id) => books.Find(x => x.BookId == id))
    .WithName(GetBookEndpointName);

// Create book
app.MapPost("books", (CreateBookDto newBook) => {
    var book = new BookDto(
          books.Count + 1,
          newBook.Title,
           newBook.PublicationYear,
           newBook.Type,
           newBook.Genre);

    books.Add(book);

    return Results.CreatedAtRoute(GetBookEndpointName, new {id = book.BookId}, book);
});

// Update book
app.MapPut("books/{id}", (int id, UpdateBookDto updatedBook) => {
    var bookIndex = books.FindIndex(x => x.BookId == id);

    books[bookIndex] = new BookDto(id,
        updatedBook.Title,
        updatedBook.PublicationYear,
        updatedBook.Type,
        updatedBook.Genre);
    
    return Results.NoContent();
});

// Delete book
app.MapDelete("books/{id}", (int id) => {
    books.RemoveAll(x => x.BookId == id);

    return Results.NoContent();
});


app.Run();
