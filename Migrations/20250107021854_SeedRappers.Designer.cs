﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyFirstApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250107021854_SeedRappers")]
    partial class SeedRappers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TotalStars")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jay-Z",
                            TotalStars = 0,
                            Username = "jayz"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kanye West",
                            TotalStars = 0,
                            Username = "kanyewest"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Eminem",
                            TotalStars = 0,
                            Username = "eminem"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tupac Shakur",
                            TotalStars = 0,
                            Username = "tupac"
                        },
                        new
                        {
                            Id = 5,
                            Name = "The Notorious B.I.G.",
                            TotalStars = 0,
                            Username = "biggie"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Drake",
                            TotalStars = 0,
                            Username = "drake"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Kendrick Lamar",
                            TotalStars = 0,
                            Username = "kendricklamar"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Lil Wayne",
                            TotalStars = 0,
                            Username = "lilwayne"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Nicki Minaj",
                            TotalStars = 0,
                            Username = "nickiminaj"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Snoop Dogg",
                            TotalStars = 0,
                            Username = "snoopdogg"
                        });
                });

            modelBuilder.Entity("StarPurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("numeric");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StarsPurchased")
                        .HasColumnType("integer");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("StarPurchases");
                });

            modelBuilder.Entity("StarPurchase", b =>
                {
                    b.HasOne("Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });
#pragma warning restore 612, 618
        }
    }
}
