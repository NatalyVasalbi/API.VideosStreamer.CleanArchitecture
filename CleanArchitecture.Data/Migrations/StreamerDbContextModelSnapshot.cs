﻿// <auto-generated />
using CleanArchitecture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Data.Migrations
{
    [DbContext(typeof(StreamerDbContext))]
    partial class StreamerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CleanArchitecture.Domain.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideoId")
                        .IsUnique();

                    b.ToTable("Director");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Streamer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Streamers");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreamerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StreamerId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.VideoActor", b =>
                {
                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.HasKey("VideoId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("VideoActor");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Director", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Video", "Video")
                        .WithOne("Director")
                        .HasForeignKey("CleanArchitecture.Domain.Director", "VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Video");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Video", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Streamer", "Stremear")
                        .WithMany("Videos")
                        .HasForeignKey("StreamerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Stremear");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.VideoActor", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Actor", "Actor")
                        .WithMany("VideoActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.Domain.Video", "Video")
                        .WithMany("VideoActors")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Actor", b =>
                {
                    b.Navigation("VideoActors");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Streamer", b =>
                {
                    b.Navigation("Videos");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Video", b =>
                {
                    b.Navigation("Director");

                    b.Navigation("VideoActors");
                });
#pragma warning restore 612, 618
        }
    }
}
