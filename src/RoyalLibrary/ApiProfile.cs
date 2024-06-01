using AutoMapper;
using RoyalLibrary.Domain.Model;
using RoyalLibrary.ViewModels;

namespace RoyalLibrary;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<BookFilterViewModel, BookFilter>();
    }
}