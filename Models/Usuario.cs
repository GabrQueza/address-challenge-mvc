namespace AddressChallenge.Models;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    
    public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
}
