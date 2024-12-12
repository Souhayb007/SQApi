using SQLi.Chalenge.DAL.Model;
using SQLi.Service;

namespace SQLiTest
{
    public class UnitTest1
    {
        
             private BookService _bookService;

        // Constructeur pour initialiser BookService avant chaque test
        public UnitTest1()
        {
            // Initialiser une nouvelle instance de BookService
            _bookService = new BookService();
        }

        [Fact]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            // Act : R�cup�rer tous les livres
            var result = _bookService.GetAllBooks();

            // Assert : V�rifier que la liste n'est pas nulle et contient des livres
            Assert.NotNull(result);
            Assert.True(result.Any()); // V�rifier qu'il y a au moins un livre
        }

        [Fact]
        public void GetBookById_ShouldReturnCorrectBook()
        {
            // Act : R�cup�rer un livre avec un ID valide
            var result = _bookService.GetBookById(1);

            // Assert : V�rifier que le livre retourn� est correct
            Assert.NotNull(result);
            Assert.Equal(1, result.id); // V�rifier que l'ID correspond
        }

        [Fact]
        public void GetBookById_ShouldReturnNull_WhenBookDoesNotExist()
        {
            // Act : R�cup�rer un livre avec un ID inexistant
            var result = _bookService.GetBookById(999);

            // Assert : V�rifier que le r�sultat est null
            Assert.Null(result);
        }

        [Fact]
        public void AddBook_ShouldAddBookToList()
        {
            // Arrange : Cr�er un nouveau livre
            var newBook = new Book
            {
                title = "New Book",
                Author = "New Author",
                ISBN = "1234567890",
                price = 19.99
            };

            // Act : Ajouter le livre
            _bookService.AddBook(newBook);

            // Assert : V�rifier que le livre a �t� ajout�
            var addedBook = _bookService.GetAllBooks().FirstOrDefault(b => b.title == "New Book");
            Assert.NotNull(addedBook);
            Assert.Equal("New Author", addedBook.Author);
        }

        [Fact]
        public void UpdateBook_ShouldUpdateExistingBook()
        {
            // Arrange : Cr�er une version mise � jour d'un livre
            var updatedBook = new Book
            {
                title = "Updated Title",
                Author = "Updated Author",
                ISBN = "9876543210",
                price = 25.99
            };

            // Act : Mettre � jour un livre avec ID 1
            _bookService.UpdateBook(1, updatedBook);

            // Assert : V�rifier que le livre a �t� mis � jour
            var book = _bookService.GetBookById(1);
            Assert.NotNull(book);
            Assert.Equal("Updated Title", book.title);
            Assert.Equal("Updated Author", book.Author);
        }

        [Fact]
        public void DeleteBook_ShouldRemoveBookFromList()
        {
            // Act : Supprimer un livre avec ID 1
            _bookService.DeleteBook(1);

            // Assert : V�rifier que le livre a �t� supprim�
            var book = _bookService.GetBookById(1);
            Assert.Null(book);
        }
    }

}
   