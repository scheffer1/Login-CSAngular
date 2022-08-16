using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Login___CSAngular.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName ="varchar(150)")]
        public string FullName { get; set; }
        
        [Column(TypeName ="varchar(11)")]
        public string Cpf { get; set; }
        
        [Column(TypeName ="varchar(150)")]
        public string Adrress { get; set; }
    }
}