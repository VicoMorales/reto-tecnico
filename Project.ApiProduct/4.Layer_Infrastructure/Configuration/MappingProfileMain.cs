using AutoMapper;
using Project.ApiProduct._2.Layer_Application.Dtos;
using Project.ApiProduct._3.Layer_Persistence._3._1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ApiProduct._4.Layer_Infrastructure.Configuration
{
    public class MappingProfileMain: Profile
    {
        public MappingProfileMain()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
