using Application.Responses;
using Domain.Entitis;
using Application.DTOs;
using System;
using Application.Responses;

public interface IBookService
{
    Task<Response<string>> AddAuthor(AddBookDto bookDto);
    Task<Response<List<BookDto>>> GetAll();
    Task<Response<BookDto>> GetById(int bookId);
    Task<Response<string>> Update(UpdateBookDto bookDto);
    Task<Response<string>> Delete(int bookId);
}