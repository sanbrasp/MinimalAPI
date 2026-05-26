namespace MinimalAPI.Services;

public class BookService
{
    private readonly List<Book> _books = new()
    {
        new Book(1, "The Hobbit", "J.R.R. Tolkien"),
        new Book(2, "1984", "George Orwell"),
        new Book(3, "Dune", "Frank Herbert")
    };

    public List<Book> GetAll() => _books;
    
    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);
}