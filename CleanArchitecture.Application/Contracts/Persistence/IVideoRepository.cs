using CleanArchitecture.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    // el metodo IVideoRepository esta heredando todos los metodos del IAsyncRepository
    // y adicional el metodo personalizado GetVideoByNombre
    public interface IVideoRepository: IAsyncRepository<Video>
    {
        // agregar netodos personalizados
        Task<Video> GetVideoByNombre(string nombreVideo);

        // Para obtener todos los videos registrados por un usuario
        Task<IEnumerable<Video>> GetVideoByUsername(string username); 
    }
}
