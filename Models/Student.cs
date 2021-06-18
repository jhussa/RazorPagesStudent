using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesStudent.Models
{
    public class Student
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime RecertifiedDate { get; set; }

        public string Address { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
         [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal TandF { get; set; }
        
        [StringLength(10)]
        [Required]
        public string Program { get; set; }
    }
}