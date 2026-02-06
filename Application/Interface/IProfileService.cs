using Application.Responses;
using Domain.Entitis;
using Application.DTOs;
using System;
using Application.Responses;

public interface IProfileService
{
   Task<Response<string>> Add(int userId,string Name);
   Task<Response<List<ProfileDto>>> GetAll();
}