using CleanArchitecture.Domain.Common;
using System.Collections.Generic;

namespace CleanArchitecture.Domain
{
    public class Actor:BaseDomainModel
    {
        public Actor()
        {
            VideoActors = new HashSet<VideoActor>();
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        //public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<VideoActor> VideoActors { get; set; }
    }
}
