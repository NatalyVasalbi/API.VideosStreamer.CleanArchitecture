using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Application.Exceptions
{
    // cuando se dispare esta excepcion por cuestiones de validaciones, se disparan todas las validaciones
    // porque el cliente no cumplio con enviarme la data solicitada o rompio las reglas de validacion
    public class ValidationException: ApplicationException
    {
        // sobrecargamos al padre, por eso llamamos al base, el mensaje por defecto
        public ValidationException():base("Se presentaron uno o mas errores de validacion")
        {
            Errors = new Dictionary<string, string[]>();
        }
        // this => que se ha referenciado a esta misma clase
        public ValidationException(IEnumerable<ValidationFailure> failures) : this() 
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        // agrupamos el conjunto de errores de validacion en un solo bloque
        public IDictionary<string, string[]> Errors { get; }
    }
}
