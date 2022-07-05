using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    // Implementacion de la interface de comunicacion MediaTR
    // dos parametros de entrada(origen, lista que devuelve)
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        // Inyectamos el IVideoRepository, que devolvera una lista de Videos. Pero lo que queremos que devuleva es una lista de VideosVm
        // Hacemos un mapeo con la libreria IMapper
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            // aqui implementaré la logica para hacer consulta a la BD, que me obtenga la lista de videos por el username
            // IVideoRepository es la encargada de hacer esta transaccion
            var videoList = await _videoRepository.GetVideoByUsername(request._Username);
            // transformacion de videoList a VideosVm
            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}
