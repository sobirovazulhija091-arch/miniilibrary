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

public class AuthorService(IAuthorRepo authorRepo): IAuthorService
{
    private readonly IAuthorRepo repository = authorRepo;

    public async Task<Response<string>> AddAuthor(AddAuthorDto authorDto)
    {
        var author = new Author()
        {
            FullName = authorDto.FullName,
            BirthDate= authorDto.BirthDate,
            Country = authorDto.Country
        };
        await repository.CreateAsync(author);
        return new Response<string>(HttpStatusCode.OK, "Added successfully!");
    }
    public async Task<Response<string>> Delete(int authorId)
    {
        var a = await repository.Authors.FindAsync(authorId);
            repository.Authors.DeleteAsync(a);
            await repository.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Deleted successfully!");   
    }
    public async Task<Response<List<AuthorDto>>> GetAll()
    {
        var res = await repository.GetAllAsync();
        var authors  = res.Select(a=> new AuthorDto()
        {
                Id = a.Id,
                FullName = a.FullName,
                Country = a.Country
        }).ToList();
        return new Response<List<AuthorDto>>(HttpStatusCode.OK, "ok", authors);  
    }

    public Task<Response<AuthorDto>> GetById(int authorId)
    {
         var res =  repository.Authors.FindAsync(authorId);
        return new Response<Author>(HttpStatusCode.OK,"OK",res);
    }

    public Task<Response<string>> Update(UpdateAuthorDto authorDto)
    {
        throw new NotImplementedException();
    }
}