using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
  public class WhenExecutePost : UsersTests
  {
    private IUserService _service;
    private Mock<IUserService> _serviceMock;

    [Fact(DisplayName = "É possível executar o Post.")]
    public async Task E_Possivel_Executar_Metodo_Post()
    {
      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
      _service = _serviceMock.Object;

      var _result = await _service.Post(userDtoCreate);
      Assert.NotNull(_result);
      Assert.Equal(UserName, _result.Name);
      Assert.Equal(UserEmail, _result.Email);
    }
  }
}