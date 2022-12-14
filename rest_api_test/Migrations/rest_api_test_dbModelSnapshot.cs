// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rest_api_test;

#nullable disable

namespace rest_api_test.Migrations
{
    [DbContext(typeof(rest_api_test_db))]
    partial class rest_api_test_dbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("rest_api_test.user", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("alamat")
                        .IsRequired()
                        .HasMaxLength(900)
                        .HasColumnType("varchar(900)")
                        .HasColumnName("alamat");

                    b.Property<string>("input_by")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("input_by");

                    b.Property<DateTime>("input_date")
                        .HasMaxLength(8)
                        .HasColumnType("datetime")
                        .HasColumnName("input_date");

                    b.Property<string>("jenis_identitas")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("jenis_identitas");

                    b.Property<string>("jenis_kelamin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("jenis_kelamin");

                    b.Property<string>("nama")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nama");

                    b.Property<string>("no_identitas")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("no_identitas");

                    b.Property<string>("tempat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tempat");

                    b.Property<DateTime>("tgl_lahir")
                        .HasMaxLength(3)
                        .HasColumnType("datetime")
                        .HasColumnName("tgl_lahir");

                    b.HasKey("id");

                    b.ToTable("user", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
