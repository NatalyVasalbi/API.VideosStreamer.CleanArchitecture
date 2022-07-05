using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = CleanArchitecture.Application.Exceptions.ValidationException;

namespace CleanArchitecture.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //verifico si tengo alguna validacion escrita en mi aplicacion
            if (_validators.Any())
            {
                //hago la evaluacion de cada validacion vs la propiedad del obj request que me envia el cliente
                var context = new ValidationContext<TRequest>(request);
                //capturo todas las vaidaciones que e escrito en mi aplicacion y las ejecuta en el tubo pipeline
                // al ejecutarlo en el tubo voy a saber si tengo algun error, si lo tengo, detengo el flujo del request
                var validatioResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                // para saber si tengo alguna validacion con error
                var failures = validatioResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                {
                    // va a detener el request dentro del tubo
                    throw new ValidationException(failures);
                }
            }
            return await next;
        }
    }
}
