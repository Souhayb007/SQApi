using SQLi.Chalenge.DAL.Model;
using SQLi.Chalenge.DTO;

namespace SQLi.Mapper
{
    public class BookMapper
    {
        public static Book BookToBookDTO(BookDTO bookDTO)
        {
            var book = new Book
            {
                title = bookDTO.title,
                ISBN = bookDTO.ISBN,
                price = bookDTO.price,
                Author = bookDTO.Author,

            };
            return book;
        }
    }
}
