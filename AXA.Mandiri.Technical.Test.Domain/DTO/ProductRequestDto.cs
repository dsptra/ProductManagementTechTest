using System.ComponentModel.DataAnnotations;

namespace AXA.Mandiri.Technical.Test.Domain.DTO
{
    public class ProductRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = default!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = default!;

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater equal than 1")]
        public decimal Price { get; set; }
    }
}
