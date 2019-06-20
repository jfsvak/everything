﻿// <auto-generated />
using System;
using EVErything.Business.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EVErything.Business.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190617112224_RemoveDummyName")]
    partial class RemoveDummyName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("EVErything.Business.Models.Account", b =>
                {
                    b.Property<byte[]>("ID")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("EVErything.Business.Models.Character", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("AccountID")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<byte[]>("CharacterSetID")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("CharacterSetID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("EVErything.Business.Models.CharacterSet", b =>
                {
                    b.Property<byte[]>("ID")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("MainCharacterID");

                    b.HasKey("ID");

                    b.HasIndex("MainCharacterID");

                    b.ToTable("CharacterSets");
                });

            modelBuilder.Entity("EVErything.Business.Models.ESIDataCache", b =>
                {
                    b.Property<byte[]>("ID")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("CharacterID")
                        .IsRequired();

                    b.Property<string>("Data");

                    b.Property<string>("ESIRoute")
                        .IsRequired();

                    b.Property<string>("ESISource")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdateTimestamp");

                    b.HasKey("ID");

                    b.HasIndex("CharacterID");

                    b.ToTable("ESIDataCaches");
                });

            modelBuilder.Entity("EVErything.Business.Models.Token", b =>
                {
                    b.Property<string>("CharacterID");

                    b.Property<string>("AccessToken")
                        .IsRequired();

                    b.Property<int?>("ExpiresIn");

                    b.Property<string>("RefreshToken")
                        .IsRequired();

                    b.Property<string>("TokenType")
                        .IsRequired();

                    b.HasKey("CharacterID");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("EVErything.Business.Models.Character", b =>
                {
                    b.HasOne("EVErything.Business.Models.Account", "Account")
                        .WithMany("Characters")
                        .HasForeignKey("AccountID");

                    b.HasOne("EVErything.Business.Models.CharacterSet", "CharacterSet")
                        .WithMany()
                        .HasForeignKey("CharacterSetID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EVErything.Business.Models.CharacterSet", b =>
                {
                    b.HasOne("EVErything.Business.Models.Character", "MainCharacter")
                        .WithMany()
                        .HasForeignKey("MainCharacterID");
                });

            modelBuilder.Entity("EVErything.Business.Models.ESIDataCache", b =>
                {
                    b.HasOne("EVErything.Business.Models.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EVErything.Business.Models.Token", b =>
                {
                    b.HasOne("EVErything.Business.Models.Character", "Character")
                        .WithOne("Token")
                        .HasForeignKey("EVErything.Business.Models.Token", "CharacterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
