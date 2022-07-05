using CleanArchitecture.Domain.Common;
using System.Collections.Generic;

namespace CleanArchitecture.Domain
{
    public class Video:BaseDomainModel
    {
        public Video()
        {
            VideoActors = new HashSet<VideoActor>();
        }
        public string? Nombre { get; set; }
        public int StreamerId { get; set; }
        public virtual Streamer? Stremear { get; set; }
        //public virtual ICollection<Actor>Actores{ get; set; }
        public virtual ICollection<VideoActor> VideoActors { get; set; }
        public virtual Director Director { get; set; }
    }
}
