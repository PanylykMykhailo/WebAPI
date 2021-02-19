﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

namespace WebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210219133022_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.Accounts", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Incidents")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Username");

                    b.HasIndex("Incidents");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("WebAPI.Models.Contacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Username");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("WebAPI.Models.Incidents", b =>
                {
                    b.Property<string>("IncidentName")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IncidentName");

                    b.ToTable("Incident");
                });

            modelBuilder.Entity("WebAPI.Models.Accounts", b =>
                {
                    b.HasOne("WebAPI.Models.Incidents", "Incident")
                        .WithMany("Account")
                        .HasForeignKey("Incidents");

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("WebAPI.Models.Contacts", b =>
                {
                    b.HasOne("WebAPI.Models.Accounts", "Account")
                        .WithMany("Contact")
                        .HasForeignKey("Username");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebAPI.Models.Accounts", b =>
                {
                    b.Navigation("Contact");
                });

            modelBuilder.Entity("WebAPI.Models.Incidents", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
