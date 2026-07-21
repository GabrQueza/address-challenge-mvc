using System.ComponentModel.DataAnnotations;

namespace AddressChallenge.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "O usuário é obrigatório")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Senha { get; set; } = string.Empty;
}
