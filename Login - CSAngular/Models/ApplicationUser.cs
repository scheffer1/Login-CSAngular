using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Login___CSAngular.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName ="nvarchar(150)")]
        public string FullName { get; set; }
        
        [Column(TypeName ="nvarchar(11)")]
        public string Cpf { get; set; }
        
        [Column(TypeName ="nvarchar(150)")]
        public string Adrress { get; set; }
    }
}