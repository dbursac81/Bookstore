using AutoMapper;
using Bookstore.Application.Dtos;
using Bookstore.Application.VMs;
using Bookstore.Domain.Entities;

namespace Bookstore.Application.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookDto, Book>();
        CreateMap<Book, BookVM>();
    }
}
