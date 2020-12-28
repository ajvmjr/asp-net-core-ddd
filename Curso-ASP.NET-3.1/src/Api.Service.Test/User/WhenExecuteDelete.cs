using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
  public class WhenExecuteDelete : UsersTests
  {
    private IUserService _service;
    private Mock<IUserService> _serviceMock;

    [Fact(DisplayName = "É possível executar o Delete.")]
    public async Task E_Possivel_Executar_Metodo_Delete()
    {
      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
      _service = _serviceMock.Object;

      var _deleted = await _service.Delete(UserId);
      Assert.True(_deleted);

      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
      _service = _serviceMock.Object;

      _deleted = await _service.Delete(Guid.NewGuid());
      Assert.False(_deleted);
    }
  }
}