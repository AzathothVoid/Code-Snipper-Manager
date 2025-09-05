using Application.DTOs.Snippet;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Snippet, SnippetDto>().ReverseMap();
            CreateMap<Snippet, CreateSnippetDto>().ReverseMap();
            CreateMap<Snippet, UpdateSnippetDto>().ReverseMap();
            CreateMap<CreateSnippetDto, UpdateSnippetDto>().ReverseMap();
        }
    }
}
