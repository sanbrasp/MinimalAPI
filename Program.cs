var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Data
var books = new List<Book>
{
    new Book(1, "The Hobbit", "J.R.R. Tolkien"),
    new Book(2, "1984", "George Orwell"),
    new Book(3, "Dune", "Frank Herbert")
};


app.MapGet("/books", () => books);

app.MapGet("/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(b => b.Id == id);
    return book is not null ? Results.Ok(book) : Results.NotFound();
});

app.Run();


// Model
record Book(int Id, string Title, string Author);