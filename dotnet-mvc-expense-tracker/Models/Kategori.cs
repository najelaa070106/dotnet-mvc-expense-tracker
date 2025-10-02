using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc_expense_tracker.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required]
        public string? Tipe { get; set; } // income / expense

        [Required]
        public string? Nama { get; set; }

        public string? Deskripsi { get; set; }

        [Required]
        public string? Status { get; set; } // active / not active
    }
}
