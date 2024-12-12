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
            // Act : Récupérer tous les livres
            var result = _bookService.GetAllBooks();

            // Assert : Vérifier que la liste n'est pas nulle et contient des livres
            Assert.NotNull(result);
            Assert.True(result.Any()); // Vérifier qu'il y a au moins un livre
        }

        [Fact]
        public void GetBookById_ShouldReturnCorrectBook()
        {
            // Act : Récupérer un livre avec un ID valide
            var result = _bookService.GetBookById(1);

            // Assert : Vérifier que le livre retourné est correct
            Assert.NotNull(result);
            Assert.Equal(1, result.id); // Vérifier que l'ID correspond
        }

        [Fact]
        public void GetBookById_ShouldReturnNull_WhenBookDoesNotExist()
        {
            // Act : Récupérer un livre avec un ID inexistant
            var result = _bookService.GetBookById(999);

            // Assert : Vérifier que le résultat est null
            Assert.Null(result);
        }

        [Fact]
        public void AddBook_ShouldAddBookToList()
        {
            // Arrange : Créer un nouveau livre
            var newBook = new Book
            {
                title = "New Book",
                Author = "New Author",
                ISBN = "1234567890",
                price = 19.99
            };

            // Act : Ajouter le livre
            _bookService.AddBook(newBook);

            // Assert : Vérifier que le livre a été ajouté
            var addedBook = _bookService.GetAllBooks().FirstOrDefault(b => b.title == "New Book");
            Assert.NotNull(addedBook);
            Assert.Equal("New Author", addedBook.Author);
        }

        [Fact]
        public void UpdateBook_ShouldUpdateExistingBook()
        {
            // Arrange : Créer une version mise à jour d'un livre
            var updatedBook = new Book
            {
                title = "Updated Title",
                Author = "Updated Author",
                ISBN = "9876543210",
                price = 25.99
            };

            // Act : Mettre à jour un livre avec ID 1
            _bookService.UpdateBook(1, updatedBook);

            // Assert : Vérifier que le livre a été mis à jour
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

            // Assert : Vérifier que le livre a été supprimé
            var book = _bookService.GetBookById(1);
            Assert.Null(book);
        }
    }

}
   