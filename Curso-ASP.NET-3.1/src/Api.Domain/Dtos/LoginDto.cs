using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
  public class LoginDto
  {
    [Required(ErrorMessage = "Digite o email para realizar o Login.")]
    [EmailAddress(ErrorMessage = "Digite um email com um formato válido.")]
    [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
    public string Email { get; set; }
  }
}