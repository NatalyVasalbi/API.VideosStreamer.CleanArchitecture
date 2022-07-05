
using System;

namespace CleanArchitecture.Domain.Common
{
    // la clase debe ser abstracta, que no permita instancia creacion de objetos directamen.
    // Solo la estamos utilizando para hacer la herencia
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        // propiedades de auditoria
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
