namespace SQLi.Chalenge.DAL.Model
{
    public class Book
    {

        public int id { get; set; }

        public string title { get; set; }
        public string ISBN { get; set; }

        public double price { get; set; }

        public string Author { get; set; }

        public static int identifiant { get; set; }
        public Book()
        {
            this.id = ++identifiant;

        }
    }
}
