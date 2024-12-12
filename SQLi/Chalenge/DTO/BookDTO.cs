using System.ComponentModel.DataAnnotations;

namespace SQLi.Chalenge.DTO
{
    public class BookDTO
    {
        [Required(ErrorMessage = "Le titre est obligatoire.")]
        public string title { get; set; }

        [Required(ErrorMessage = "ISBN est obligatoire.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire.")]
        public double price { get; set; }

        [Required(ErrorMessage = "L'auteur est obligatoire.")]
        public string Author { get; set; }
    }
}
