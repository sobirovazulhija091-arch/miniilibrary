using Application.Responses;
using Domain.Entitis;
using Application.DTOs;
using System;
using Application.Responses;

public interface IUserService
{
    Task<Response<string>> AddAuthor(AddUserDto userDto);
    Task<Response<List<UserDto>>> GetAll();
    Task<Response<UserDto>> GetById(int userId);
    Task<Response<string>> Update(UpdateUserDto userDto);
    Task<Response<string>> Delete(int userId);
}