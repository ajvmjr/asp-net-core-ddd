using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
  public class WhenExecuteFindByLogin
  {
    private ILoginService _service;
    private Mock<ILoginService> _serviceMock;

    [Fact(DisplayName = "É possível executar o método FindByLogin.")]
    public async Task E_Possivel_Executar_FindByLogin()
    {
      var email = Faker.Internet.Email();
      var objectedReturn = new
      {
        authenticated = true,
        created = DateTime.UtcNow,
        expiration = DateTime.UtcNow.AddHours(8),
        accessToken = Guid.NewGuid(),
        userName = email,
        name = Faker.Name.FullName(),
        message = "Usuário logado com sucesso."
      };

      var loginDto = new LoginDto
      {
        Email = email
      };

      _serviceMock = new Mock<ILoginService>();
      _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objectedReturn);
      _service = _serviceMock.Object;

      var result = await _service.FindByLogin(loginDto);
      Assert.NotNull(result);
    }
  }
}