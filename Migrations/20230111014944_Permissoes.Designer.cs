﻿// <auto-generated />
using MVC_UserPermissions.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_UserPermissions.Migrations
{
    [DbContext(typeof(UserPermissionsContext))]
    [Migration("20230111014944_Permissoes")]
    partial class Permissoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVC_UserPermissions.Models.CategoriaProduto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaProduto");
                });

            modelBuilder.Entity("MVC_UserPermissions.Models.Permissao", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissao");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Key = "10001000",
                            Nome = "Listar Produto"
                        },
                        new
                        {
                            Id = 2L,
                            Key = "10002000",
                            Nome = "Criar Produto"
                        },
                        new
                        {
                            Id = 3L,
                            Key = "10003000",
                            Nome = "Editar Produto"
                        },
                        new
                        {
                            Id = 4L,
                            Key = "10004000",
                            Nome = "Deletar Produto"
                        },
                        new
                        {
                            Id = 5L,
                            Key = "20001000",
                            Nome = "Listar Categoria Produto"
                        },
                        new
                        {
                            Id = 6L,
                            Key = "20002000",
                            Nome = "Criar Categoria Produto"
                        },
                        new
                        {
                            Id = 7L,
                            Key = "20003000",
                            Nome = "Editar Categoria Produto"
                        },
                        new
                        {
                            Id = 8L,
                            Key = "20004000",
                            Nome = "Deletar Categoria Produto"
                        });
                });

            modelBuilder.Entity("MVC_UserPermissions.Models.PermissaoUsuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("PermissaoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PermissaoId");

                    b.ToTable("Permissao_Usuario");
                });

            modelBuilder.Entity("MVC_UserPermissions.Models.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CategoriaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("MVC_UserPermissions.Models.PermissaoUsuario", b =>
                {
                    b.HasOne("MVC_UserPermissions.Models.Permissao", "Permissao")
                        .WithMany()
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permissao");
                });

            modelBuilder.Entity("MVC_UserPermissions.Models.Produto", b =>
                {
                    b.HasOne("MVC_UserPermissions.Models.CategoriaProduto", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
