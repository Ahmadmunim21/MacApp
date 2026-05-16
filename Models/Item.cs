using System.ComponentModel.DataAnnotations;

namespace MacApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nama barang wajib diisi!")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Category { get; set; } = string.Empty;
        
        [Range(1, 1000, ErrorMessage = "Kuantiti mestilah antara 1 hingga 1000")]
        public int Quantity { get; set; }
        
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }
        
        public bool IsAvailable => Quantity > 0;
    }
}
