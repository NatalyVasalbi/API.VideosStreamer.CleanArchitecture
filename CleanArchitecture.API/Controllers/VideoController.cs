using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VideoController:ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{userName}", Name = "GetVideo")]
        // el tipo de dato que va a devolver
        [ProducesResponseType(typeof(IEnumerable<VideosVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VideosVm>>>GetVideosByUsername(string username)
        {
            // envio mi command/query a la capa application
            var query = new GetVideosListQuery(username);
            // enviamos el objeto query a la capa de application
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }

    }
}
