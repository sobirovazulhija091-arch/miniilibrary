using Application.Responses;
using Domain.Entitis;
using Application.DTOs;
using System;
using Application.Responses;

namespace Application.Interfaces;

public interface IBookloanService
{
    Task<Response<string>> AddAuthor(AddBookloanDto bloanDto);
    Task<Response<List<BookloanDto>>> GetAll();
    Task<Response<BookloanDto>> GetById(int bloanId);
    Task<Response<string>> Update(UpdateBookloanDto bloanDto);
    Task<Response<string>> Delete(int bloanId);
}