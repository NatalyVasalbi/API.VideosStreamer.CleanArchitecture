using AutoMapper;
using CleanArchitecture.Application.Features.Streamers.Commands;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // origen Video, destino VideosVm
            CreateMap<Video, VideosVm>();
            CreateMap<CreateStreamerCommand, Streamer>();
        }

        // Hacer las validaciones de los datos que me esta enviando el cliente
    }
}
