using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Domain.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Int32 Id { get; set; } = default!;

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string UserName { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        public DateTime CreatedAt { get; set; } = default!;
    }
}
