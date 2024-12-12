using SQLi.Chalenge.DAL.Model;

namespace SQLi.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(); // Récupérer tous les livres
        Book GetBookById(int id); // Récupérer un livre par ID
        void AddBook(Book book); // Ajouter un livre
        void UpdateBook(int id, Book updatedBook); // Mettre à jour un livre
        void DeleteBook(int id); // Supprimer un livre
    }
}
