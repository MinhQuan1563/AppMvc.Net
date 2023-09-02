using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppMvc.Net.Models
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "nvarchar")]
        [StringLength(400)]
        public string? HomeAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}
