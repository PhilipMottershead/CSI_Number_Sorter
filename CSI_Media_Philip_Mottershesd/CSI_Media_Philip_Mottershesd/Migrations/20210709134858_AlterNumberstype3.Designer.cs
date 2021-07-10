﻿// <auto-generated />
using System;
using CSI_Media_Philip_Mottershesd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSI_Media_Philip_Mottershesd.Migrations
{
    [DbContext(typeof(SortedNumbersContext))]
    [Migration("20210709134858_AlterNumberstype3")]
    partial class AlterNumberstype3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CSI_Media_Philip_Mottershesd.Models.SortedNumbers", b =>
                {
                    b.Property<int>("SortedNumbersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Numbers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TimeTaken")
                        .HasColumnType("time");

                    b.HasKey("SortedNumbersId");

                    b.ToTable("SortedNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
