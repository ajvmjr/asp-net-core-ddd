using Api.Domain.Dtos.User;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
  public class DtoToModelProfile : Profile
  {
    public DtoToModelProfile()
    {
      CreateMap<UserModel, UserDto>().ReverseMap();
    }
  }
}