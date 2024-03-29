﻿using AutoMapper;
using DtoLayer.ProductDto;
using EntityLayer.Entites;

namespace SignalRApi.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product,ResultProductWithCategoryDto>().ReverseMap();
            
        }
    }
}
