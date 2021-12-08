﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using LAB5.Data;

namespace LAB5.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LAB5.Models.CN_TC", b =>
                {
                    b.Property<string>("MaCongNhan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaTrieuChung")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaCongNhan", "MaTrieuChung");

                    b.HasIndex("MaTrieuChung");

                    b.ToTable("cn_tc");
                });

            modelBuilder.Entity("LAB5.Models.CongNhan", b =>
                {
                    b.Property<string>("MaCongNhan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("MaDiemCachLy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NamSinh")
                        .HasColumnType("int");

                    b.Property<string>("NuocVe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenCongNhan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaCongNhan");

                    b.HasIndex("MaDiemCachLy");

                    b.ToTable("congnhan");
                });

            modelBuilder.Entity("LAB5.Models.DiemCachLy", b =>
                {
                    b.Property<string>("MaDiemCachLy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDiemCachLy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDiemCachLy");

                    b.ToTable("diemcachly");
                });

            modelBuilder.Entity("LAB5.Models.TrieuChung", b =>
                {
                    b.Property<string>("MaTrieuChung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenTrieuChung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTrieuChung");

                    b.ToTable("trieuchung");
                });

            modelBuilder.Entity("LAB5.Models.CN_TC", b =>
                {
                    b.HasOne("LAB5.Models.CongNhan", "CongNhan")
                        .WithMany("CN_TCs")
                        .HasForeignKey("MaCongNhan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAB5.Models.TrieuChung", "TrieuChung")
                        .WithMany("CN_TCs")
                        .HasForeignKey("MaTrieuChung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CongNhan");

                    b.Navigation("TrieuChung");
                });

            modelBuilder.Entity("LAB5.Models.CongNhan", b =>
                {
                    b.HasOne("LAB5.Models.DiemCachLy", "DiemCachLy")
                        .WithMany("CongNhans")
                        .HasForeignKey("MaDiemCachLy");

                    b.Navigation("DiemCachLy");
                });

            modelBuilder.Entity("LAB5.Models.CongNhan", b =>
                {
                    b.Navigation("CN_TCs");
                });

            modelBuilder.Entity("LAB5.Models.DiemCachLy", b =>
                {
                    b.Navigation("CongNhans");
                });

            modelBuilder.Entity("LAB5.Models.TrieuChung", b =>
                {
                    b.Navigation("CN_TCs");
                });
#pragma warning restore 612, 618
        }
    }
}