using AutoMapper;
using Domain.Categories;
using Domain.Entities;
using DTOS.CatalogCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //CreateMap<Accessories, AccessoriesDTO>().ReverseMap();
        //CreateMap<Book, AddBookDtos>().ReverseMap();
        //CreateMap<UpdateBookDtos, Book>();

        CreateMap<Catalogcategory, CatalogCategoryDTO>().ReverseMap();
        CreateMap<Catalogcategory, AddCatalogCategoryDTO>().ReverseMap();
        CreateMap<UpdateCatalogCategoryDTO, Catalogcategory>();
    }
}
