using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.WhenRequestUpdate
{
  public class Return_BadRequest
  {
    private UsersController _controller;

    [Fact(DisplayName = "É possível realizar o Updated.")]
    public async Task E_Possivel_Invocar_Controller_Update()
    {
      var serviceMock = new Mock<IUserService>();
      var name = Faker.Name.FullName();
      var email = Faker.Internet.Email();

      serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
          new UserDtoUpdateResult
          {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            UpdateAt = DateTime.UtcNow
          }
      );

      _controller = new UsersController(serviceMock.Object);
      _controller.ModelState.AddModelError("Email", "É um campo obrigatório.");

      var userDtoUpdate = new UserDtoUpdate
      {
        Id = Guid.NewGuid(),
        Name = name,
        Email = email
      };

      var result = await _controller.Put(userDtoUpdate);
      Assert.True(result is BadRequestObjectResult);
      Assert.False(_controller.ModelState.IsValid);
    }
  }
}