using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();
await MultipleEntitiesQuery();
//await AddNewDirectorWithVideo();
//await AddNewActorWithVideo();
//await AddNewStreamerWithVideoId();
//await AddNewStreamerWithVideo();
//await QueryLinq();
//await QueryFilter();
//await QueryMethods();

Console.WriteLine("Presione cualquier tecla para terminar el programa");
Console.ReadKey();

async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext.Videos.Include(q => q.VideoActors).FirstOrDefaultAsync(q => q.Id == 1);
    var videoWithDirector = await dbContext.Videos
        .Where(q=>q.Director != null)
        .Include(q => q.Director)
        .Select(q =>
        new
        {
            Director_Nombre_Completo = $"{q.Director.Nombre} {q.Director.Apellido}",
            Movie = q.Nombre
        }
        ).ToListAsync();
    foreach (var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie} - {pelicula.Director_Nombre_Completo}");
    }
}
async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1
    };
    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}
async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pitt"
    };
    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };
    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}
async Task AddNewStreamerWithVideoId()
{
    var batmanForever = new Video
    {
        Nombre = "Batman forever",
        StreamerId = 1002
    };
    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();
}
async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer
    {
        Nombre = "Pantaya"
    };
    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Stremear = pantaya
    };
    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}
async Task TrackingAndNotTracking()
{
    // Tracking: el objeto se queda en mememoria y se puede hacer cambios
    var streamerWithTracking = await dbContext.Streamers.FirstOrDefaultAsync(x => x.Id == 1);
    // NoTracking: el objeto se borra de memoria y no hay con que hacer objeto hacer cambios
    var streamerWithNoTracking = await dbContext.Streamers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWithTracking.Nombre = "Netflix Super";
    streamerWithNoTracking.Nombre = "Amazon Plus";

    await dbContext.SaveChangesAsync();
}
async Task QueryLinq()
{
    Console.WriteLine($"Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine();

    var streamers = await (from i in dbContext.Streamers 
                           where EF.Functions.Like(i.Nombre, $"%{streamerNombre}%")
                           select i).ToListAsync();
    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
async Task QueryMethods()
{
    var streamer = dbContext.Streamers;
    // FirstAsync de la lista solo nos devuelve un record, salta una excepción si no encuentra
    var firstAsync = await streamer.Where(y => y.Nombre.Contains("a")).FirstAsync();
    // FirstOrDefaultAsync de la lista solo nos devuelve un record, salta null si no encuentra
    var firstOrDefaultAsync = await streamer.Where(y => y.Nombre.Contains("a")).FirstOrDefaultAsync();
    var firstOrDefaultAsync_v2 = await streamer.FirstOrDefaultAsync(y=> y.Nombre.Contains("a"));
    // SingleAsync el resultado debe ser un unico valor, si es más o vacio salta una excepcion
    var singleAsync = await streamer.Where(y => y.Id == 1).SingleAsync();
    // SingleOrDefaultAsync el resultado debe ser un unico valor, si es más o vacio devuelve null
    var singleOrDefaultAsync = await streamer .Where(y => y.Id == 1).SingleAsync();

    //busca por Id un solo record
    var resultado = await streamer .FindAsync(1);
}
async Task QueryFilter()
{
    Console.WriteLine($"Ingrese una compañia de streaming: ");
    var streamingNombre = Console.ReadLine();
    var streamers = await dbContext.Streamers.Where(x => x.Nombre.Equals(streamingNombre)).ToListAsync();
    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

    //var streamerPartialResults = await dbContext.Stremears.Where(x => x.Nombre.Contains(streamingNombre)).ToListAsync();
    var streamerPartialResults = await dbContext.Streamers.Where(x => EF.Functions.Like(x.Nombre, $"%{streamingNombre}%")).ToListAsync();
    foreach (var streamer in streamerPartialResults)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();
    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
//Streamer streamer = new()
//{
//    Nombre = "Amazon Prime",
//    Url = "https://www.amazonprime.com"
//};

//dbContext!.Stremears!.Add(streamer);
//await dbContext.SaveChangesAsync();

//var movies = new List<Video>
//{
//    new Video
//    {
//        Nombre="Mad Max",
//        StreamerId=streamer.Id,

//    },
//    new Video
//    {
//        Nombre="Batman",
//        StreamerId=streamer.Id,

//    },
//    new Video
//    {
//        Nombre="Crepusculo",
//        StreamerId=streamer.Id,

//    },
//    new Video
//    {
//        Nombre="Citizen Kane",
//        StreamerId=streamer.Id,

//    }
//};

//await dbContext.AddRangeAsync(movies);
//await dbContext.SaveChangesAsync();
