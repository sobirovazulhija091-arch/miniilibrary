using System.Net;
using Domain.Entites;
using Application.DTOs;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Application.Interface;
using Application.Responses;
using AutoMapper;
namespace Application.Services;
public class ProfileService(ApplicationDbContext dbContext) : IProfileService
{
    private readonly ApplicationDbContext context=dbContext;
    public async Task<Response<string>> Add(int userId,string Name)
    {
         Profile profile = new Profile(){UserId = userId,Nameprofile=Name};
        context.Profiles.Add(profile);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK, "added");
    }
    public async Task<Response<List<Profile>>> GetAll()
    {
        return new Response<List<Profile>>(HttpStatusCode.OK, "ok", context.Profiles.ToList());
    }
}