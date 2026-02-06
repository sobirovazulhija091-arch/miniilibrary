using Application.Responses;
using Domain.Entitis;
using Application.DTOs;
using System;
using Application.Responses;


namespace Application.Interfaces;

public interface IAuthorService
{
    Task<Response<string>> AddAuthor(AddAuthorDto authorDto);
    Task<Response<List<AuthorDto>>> GetAll();
    Task<Response<AuthorDto>> GetById(int authorId);
    Task<Response<string>> Update(UpdateAuthorDto authorDto);
    Task<Response<string>> Delete(int authorId);
}