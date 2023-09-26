﻿// <auto-generated />
using CodeChallenge02.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeChallenge02.Migrations
{
    [DbContext(typeof(PicPayContext))]
    [Migration("20230926095144_011")]
    partial class _011
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeChallenge02.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isPessoaFisica")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CodeChallenge02.Models.Lojista", b =>
                {
                    b.HasBaseType("CodeChallenge02.Models.Usuario");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Lojista");
                });

            modelBuilder.Entity("CodeChallenge02.Models.UsuarioComum", b =>
                {
                    b.HasBaseType("CodeChallenge02.Models.Usuario");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("UsuarioComum");
                });
#pragma warning restore 612, 618
        }
    }
}
