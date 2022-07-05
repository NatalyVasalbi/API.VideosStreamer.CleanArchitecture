using System;

namespace CleanArchitecture.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        // name= la clase que dispara el error
        // key= record que ha generado la excepcion
        // base= que retorne a la clase padre Application Excepcion e imprima un mensaje
        public NotFoundException(string name, object key): base($"Entity \"{name}\" ({key}) no fue encontrado")
        {

        }
    }
}
