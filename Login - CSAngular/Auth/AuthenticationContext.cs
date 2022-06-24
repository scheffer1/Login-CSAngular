using Login___CSAngular.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Login___CSAngular.Auth;

public class AuthenticationContext : IdentityDbContext
{
    public AuthenticationContext(DbContextOptions options):base(options)
    {
        
    }
    
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
}