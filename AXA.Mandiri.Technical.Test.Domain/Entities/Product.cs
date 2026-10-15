using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Domain.Entities
{
    public class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; } = default!;

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; } = default!;

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Description { get; set; } = default!;

        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Price { get; set; } = default!;

        [Required]
        public DateTime CreatedAt { get; set; } = default!;
    }

}
