using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMvc.Net.Models.Contact
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        public string FullName { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(50)]
        [Phone]
        public string? Phone { get; set; }
        public DateTime DateSent { get; set; }
        public string? Message { get; set; }
    }
}
