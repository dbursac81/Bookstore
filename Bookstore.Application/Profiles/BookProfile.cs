using AutoMapper;
using Bookstore.Application.Dtos;
using Bookstore.Application.VMs;
using Bookstore.Data.Models;

namespace Bookstore.Application.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookDto, Book>();
        CreateMap<Book, BookVM>();
    }
}
