
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext: DbContext
    {
        // cadena de conexion al servidor sql server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-BGS0L77\SQLEXPRESS;
                Initial Catalog=Streamer;Integrated Security=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        //fluentAPI declaracion de uno a muchos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //instancia a envaluar: Streamer
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Stremear)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // instancia a evaluar: Video
            //modelBuilder.Entity<Video>()
            //    .HasMany(p => p.Actores)
            //    .WithMany(t => t.Videos)
            //    .UsingEntity<VideoActor>(
            //        pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
            //    //pt => pt.HasKey(e => new {e.ActorId, e.VideoId})                                    
            //    );

            // instancia a evaluar: Video            
            //modelBuilder.Entity<Video>()
            //    .HasMany(p => p.Actores)
            //    .WithMany(t => t.Videos)
            //    .UsingEntity<VideoActor>(
            //    pt => pt.HasKey(x => new { x.ActorId,x.VideoId })                                    
            //    );

            // muchos a muchos
            modelBuilder.Entity<VideoActor>()
                .HasKey(sc => new { sc.VideoId, sc.ActorId });

            modelBuilder.Entity<VideoActor>()
                .HasOne<Video>(m => m.Video)
                .WithMany(t => t.VideoActors)
                .HasForeignKey(bc => bc.VideoId);
            modelBuilder.Entity<VideoActor>()
                .HasOne<Actor>(m => m.Actor)
                .WithMany(t => t.VideoActors)
                .HasForeignKey(bc => bc.ActorId);





        }
       
        //convierto las clases en entidades
        public DbSet<Streamer> Streamers { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}
