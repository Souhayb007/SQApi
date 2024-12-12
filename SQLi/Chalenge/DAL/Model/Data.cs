namespace SQLi.Chalenge.DAL.Model
{
    public class Data
    {

        public static List<Book> Books = new List<Book>
        {
            new Book {title="The Great Gatsby", ISBN = "9780743273565", price = 25.99, Author ="F. Scott Fitzgerald " },
            new Book {title = "To Kill a Mockingbird", ISBN = "0061120081" , price = 19.99, Author = "Harper Lee" },
            new Book {title = "1984" , ISBN = "9780451524935",price=12.50, Author = "George Orwell" },
            new Book {title = "The Catcher in the Rye", ISBN = "9780241950425", price = 15.75, Author = "J.D. Salinger"},
            new Book {title = "The Hobbit" , ISBN = "9780547928227" , price = 22.95 , Author = "J.R.R. Tolkien" }

        };
    }
}
