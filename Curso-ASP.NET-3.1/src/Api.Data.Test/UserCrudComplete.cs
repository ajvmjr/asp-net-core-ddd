using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
  public class UserCrudComplete : BaseTest, IClassFixture<DbTest>
  {
    private ServiceProvider _serviceProvider;

    public UserCrudComplete(DbTest dbTest)
    {
      _serviceProvider = dbTest.ServiceProvider;
    }

    [Fact(DisplayName = "CRUD de Usuário.")]
    [Trait("CRUD", "UserEntity")]
    public async Task E_Possivel_Realizar_CRUD_Usuario()
    {
      using (var context = _serviceProvider.GetService<MyContext>())
      {
        UserImplementation _repository = new UserImplementation(context);
        UserEntity _entity = new UserEntity
        {
          Email = "teste@mail.com",
          Name = "Teste"
        };

        var _registered = await _repository.InsertAsync(_entity);
        Assert.NotNull(_registered);
        Assert.Equal("teste@mail.com", _registered.Email);
        Assert.Equal("teste", _registered.Name);
        Assert.False(_registered.Id == Guid.Empty);
      }
    }
  }
}