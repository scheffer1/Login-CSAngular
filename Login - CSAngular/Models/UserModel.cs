using Microsoft.AspNetCore.Identity;

namespace Login___CSAngular.Models;

public class UserModel
{
    public string Phone { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Address { get; set; }
}