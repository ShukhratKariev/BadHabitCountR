using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUserService
{
    public int AddUser(AddUserDto dto);
    public User GetUserById(int id);
}