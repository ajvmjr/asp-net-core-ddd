using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
  public class UserDtoCreate
  {
    [Required(ErrorMessage = "O nome é um campo obrigatório.")]
    [StringLength(60, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O Email é um campo obrigatório.")]
    [StringLength(100, ErrorMessage = "O email deve ter no máximo {1} caracteres.")]
    public string Email { get; set; }
  }
}