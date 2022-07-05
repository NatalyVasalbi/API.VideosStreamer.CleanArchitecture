using CleanArchitecture.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            // Registramos el Asembly de la libreria que me permite hacer el mapping 
            // de las clases de origen a la clase destino
            // Automaticamente va a leer todas las clases que esten heredando
            // , implemetando las interfaces del AutoMapper y las va a inyectar
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // va a buscar todas las clases de mi proyecto Application que esten
            // referenciando al AbstractValidation y a los paquetes de FluentValidation y automaticamente va a inyectar,
            // va a instanciar, crear los objetos para que esa validacion sea posible dentro de mi proyecto
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
