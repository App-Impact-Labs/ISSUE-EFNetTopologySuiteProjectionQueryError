﻿// <auto-generated />
using EfProjectionWithTopologyError.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace EfProjectionWithTopologyError.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201115154008_Initialization")]
    partial class Initialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EfProjectionWithTopologyError.Entities.HealthInstitution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Point>("Coordinates")
                        .HasColumnType("geography");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HealthInstitutions");
                });

            modelBuilder.Entity("EfProjectionWithTopologyError.Entities.HealthInstitutionMedicalServiceLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("HealthInstitutionId")
                        .HasColumnType("int");

                    b.Property<int>("MedicalServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HealthInstitutionId");

                    b.HasIndex("MedicalServiceId");

                    b.ToTable("HealthInstitutionMedicalServiceLinks");
                });

            modelBuilder.Entity("EfProjectionWithTopologyError.Entities.MedicalService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicalServices");
                });

            modelBuilder.Entity("EfProjectionWithTopologyError.Entities.HealthInstitutionMedicalServiceLink", b =>
                {
                    b.HasOne("EfProjectionWithTopologyError.Entities.HealthInstitution", "HealthInstitution")
                        .WithMany("MedicalServiceLinks")
                        .HasForeignKey("HealthInstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfProjectionWithTopologyError.Entities.MedicalService", "MedicalService")
                        .WithMany("HealthInstitutionLinks")
                        .HasForeignKey("MedicalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthInstitution");

                    b.Navigation("MedicalService");
                });

            modelBuilder.Entity("EfProjectionWithTopologyError.Entities.HealthInstitution", b =>
                {
                    b.Navigation("MedicalServiceLinks");
                });

            modelBuilder.Entity("EfProjectionWithTopologyError.Entities.MedicalService", b =>
                {
                    b.Navigation("HealthInstitutionLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
