using SQLi.Chalenge.DAL.Model;

namespace SQLi.Service
{
    public class BookService : IBookService
    {
        public IEnumerable<Book> GetAllBooks() => Data.Books;

        public Book GetBookById(int id) => Data.Books.FirstOrDefault(b => b.id == id);

        public void AddBook(Book book)
        {
            book.id = Data.Books.Any() ? Data.Books.Max(b => b.id) + 1 : 1; // Générer un nouvel ID
            Data.Books.Add(book);
        }

        public void UpdateBook(int id, Book updatedBook)
        {
            var book = Data.Books.FirstOrDefault(b => b.id == id);
            if (book != null)
            {
                book.title = updatedBook.title;
                book.Author = updatedBook.Author;
                book.ISBN = updatedBook.ISBN;
                book.price = updatedBook.price;
            }
        }

        public void DeleteBook(int id)
        {
            var book = Data.Books.FirstOrDefault(b => b.id == id);
            if (book != null)
            {
                Data.Books.Remove(book);
            }
        }
    }
}
