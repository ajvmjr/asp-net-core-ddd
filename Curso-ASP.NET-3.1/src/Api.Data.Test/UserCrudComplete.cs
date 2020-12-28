using System;
using System.Linq;
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
          Email = Faker.Internet.Email(),
          Name = Faker.Name.FullName()
        };

        var _registered = await _repository.InsertAsync(_entity);
        Assert.NotNull(_registered);
        Assert.Equal(_entity.Email, _registered.Email);
        Assert.Equal(_entity.Name, _registered.Name);
        Assert.False(_registered.Id == Guid.Empty);

        _entity.Name = Faker.Name.First();
        var _updated = await _repository.UpdateAsync(_entity);
        Assert.NotNull(_updated);
        Assert.Equal(_entity.Email, _updated.Email);
        Assert.Equal(_entity.Name, _updated.Name);

        var _registerExists = await _repository.ExistsAsync(_updated.Id);
        Assert.True(_registerExists);

        var _selectedRegister = await _repository.SelectAsync(_updated.Id);
        Assert.NotNull(_selectedRegister);
        Assert.Equal(_updated.Email, _selectedRegister.Email);
        Assert.Equal(_updated.Name, _selectedRegister.Name);

        var _allRegisters = await _repository.SelectAllAsync();
        Assert.NotNull(_allRegisters);
        Assert.True(_allRegisters.Count() > 0);

        var _removed = await _repository.DeleteAsync(_selectedRegister.Id);
        Assert.True(_removed);

        var _defaultUser = await _repository.FindByLogin("ajvm10@gmail.com");
        Assert.NotNull(_defaultUser);
        Assert.Equal("ajvm10@gmail.com", _defaultUser.Email);
        Assert.Equal("Administrator", _defaultUser.Name);
      }
    }
  }
}