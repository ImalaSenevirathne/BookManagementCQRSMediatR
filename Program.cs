using BookManagementCQRSMediatR.Data;
using BookManagementCQRSMediatR.Features.Books.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("BooksDB"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Minimal API Endpoints
app.MapPost("/books",async (AddBookCommand cmd, IMediator mediator) =>
{
    var bookId = await mediator.Send(cmd);
    return Results.Created($"/books/{bookId}", bookId);
});

app.MapGet("/books/{id}", async (Guid id, IMediator mediator) =>
{
    var book = await mediator.Send(new BookManagementCQRSMediatR.Features.Books.Queries.GetBookByIdQuery { BookId = id});
    return book is not null ? Results.Ok(book) : Results.NotFound();
});

app.MapGet("/books", async (IMediator mediator) =>
{
    var books = await mediator.Send(new BookManagementCQRSMediatR.Features.Books.Queries.GetAllBooksQuery());
    return Results.Ok(books);
}); 

app.MapPut("/books/{id}/{title}", async (Guid id, string newTitle, IMediator mediator) =>
{
    var updated = await mediator.Send(new BookManagementCQRSMediatR.Features.Books.Commands.UpdateBookTitleCommand { BookId = id, NewTitle = newTitle });
    return updated ? Results.Ok() : Results.NotFound();
});

app.MapDelete("/books/{id}", async (Guid id, IMediator mediator) =>
{
    var deleted = await mediator.Send(new BookManagementCQRSMediatR.Features.Books.Commands.DeleteBookCommand { BookId = id });
    return deleted ? Results.NoContent() : Results.NotFound();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
