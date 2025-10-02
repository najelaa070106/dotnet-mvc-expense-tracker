using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc_expense_tracker.Models
{
    public class Budget
    {
        public int Id { get; set; }

        [Required]
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; } // Relasi ke Kategori

        [Required]
        public string? Nama { get; set; }

        public string? Deskripsi { get; set; }

        [Required]
        public decimal TotalBudget { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public bool IsRepeat { get; set; }

        [Required]
        public string? Status { get; set; } // active / not active
    }
}
