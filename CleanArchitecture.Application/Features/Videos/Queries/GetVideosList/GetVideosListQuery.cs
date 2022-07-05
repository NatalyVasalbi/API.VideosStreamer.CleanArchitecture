using MediatR;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    // Para hacer la comuicacion entre el Query y el Handler, utilizamos la libreria IRequest(MediaTR)
    // Devuelve una lista de videos (VideosVm)
    public class GetVideosListQuery:IRequest<List<VideosVm>>
    {
        public string _Username { get; set; } = String.Empty;
        public GetVideosListQuery(string username)
        {
            // en caso de que no exista el Username, que lance una excepcion 
            username = _Username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
