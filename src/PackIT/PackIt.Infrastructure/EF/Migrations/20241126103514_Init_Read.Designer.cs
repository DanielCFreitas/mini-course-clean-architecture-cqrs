﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PackIt.Infrastructure.EF.Contexts;

#nullable disable

namespace PackIt.Infrastructure.EF.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    [Migration("20241126103514_Init_Read")]
    partial class Init_Read
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("packing")
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PackIt.Infrastructure.EF.Models.PackingItemReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPacked")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PackingListId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PackingListId");

                    b.ToTable("PackingItems", "packing");
                });

            modelBuilder.Entity("PackIt.Infrastructure.EF.Models.PackingListReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Localization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PackingLists", "packing");
                });

            modelBuilder.Entity("PackIt.Infrastructure.EF.Models.PackingItemReadModel", b =>
                {
                    b.HasOne("PackIt.Infrastructure.EF.Models.PackingListReadModel", "PackingList")
                        .WithMany("Items")
                        .HasForeignKey("PackingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PackingList");
                });

            modelBuilder.Entity("PackIt.Infrastructure.EF.Models.PackingListReadModel", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
