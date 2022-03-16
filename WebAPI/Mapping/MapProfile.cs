using AutoMapper;
using Entity.Entities;
using Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;

namespace WebAPI.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>();/*.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.CategoryName)*/
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductUpdateDto>();
            CreateMap<ProductUpdateDto, Product>();

            CreateMap<Product, ProductDeleteDto>();
            CreateMap<ProductDeleteDto, Product>();

            CreateMap<Product, ProductUpdateVM>();
            CreateMap<ProductUpdateVM, Product>();

            CreateMap<Product, ProductListVM>();
            CreateMap<ProductListVM, Product>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, Category>();

            CreateMap<Category, CategoryDeleteVM>();
            CreateMap<CategoryDeleteVM, Category>();
        }
    }
}
