﻿// <auto-generated />
using System;
using HospitalApp.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalApp.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240207035757_Some")]
    partial class Some
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HospitalApp.Domain.Entities.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departaments");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.HealingEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("HealingEventTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Recommendation")
                        .HasColumnType("text");

                    b.Property<int>("RequestVisitId")
                        .HasColumnType("integer");

                    b.Property<string>("Results")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("HealingEventTypeId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RequestVisitId");

                    b.ToTable("HealingEvents");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.HealingEventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HealingEventTypes");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.Hospitalization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartamentId")
                        .HasColumnType("integer");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HospitalizationConditionId")
                        .HasColumnType("integer");

                    b.Property<int>("HospitalizationStatusId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("HospitalizationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Target")
                        .HasColumnType("text");

                    b.Property<int>("UserInfoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.HasIndex("HospitalizationConditionId");

                    b.HasIndex("HospitalizationStatusId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("Hospitalizations");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.HospitalizationCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HospitalizationConditions");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.HospitalizationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HospitalizationStatuses");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.MedicalCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long?>("Number")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserMainInfoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserMainInfoId");

                    b.ToTable("MedicalCards");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.RequestVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("VisitorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("VisitorId");

                    b.ToTable("RequestVisits");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.UserAdditional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("InsurancePolicyDateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("InsurancePolicyNumber")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserMainInfoId")
                        .HasColumnType("integer");

                    b.Property<string>("WorkPlace")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserMainInfoId");

                    b.ToTable("UserAdditionals");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.UserCredential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("UserCredentials");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.UserMainInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("GenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("PassportNumber")
                        .HasColumnType("bigint");

                    b.Property<long>("PassportSeries")
                        .HasColumnType("bigint");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMainInfos");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("MedicalCardId")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Recommendation")
                        .HasColumnType("text");

                    b.Property<int>("RequestVisitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("MedicalCardId");

                    b.HasIndex("RequestVisitId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.HealingEvent", b =>
                {
                    b.HasOne("HospitalApp.Domain.Entities.UserMainInfo", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Domain.Entities.HealingEventType", "HealingEventType")
                        .WithMany()
                        .HasForeignKey("HealingEventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Domain.Entities.UserMainInfo", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Domain.Entities.RequestVisit", "RequestVisit")
                        .WithMany()
                        .HasForeignKey("RequestVisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("HealingEventType");

                    b.Navigation("Patient");

                    b.Navigation("RequestVisit");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.Hospitalization", b =>
                {
                    b.HasOne("HospitalApp.Domain.Entities.Departament", "Departament")
                        .WithMany()
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Domain.Entities.HospitalizationCondition", "HospitalizationCondition")
                        .WithMany()
                        .HasForeignKey("HospitalizationConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Domain.Entities.HospitalizationStatus", "HospitalizationStatus")
                        .WithMany()
                        .HasForeignKey("HospitalizationStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Domain.Entities.UserMainInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departament");

                    b.Navigation("HospitalizationCondition");

                    b.Navigation("HospitalizationStatus");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.MedicalCard", b =>
                {
                    b.HasOne("HospitalApp.Domain.Entities.UserMainInfo", "UserMainInfo")
                        .WithMany()
                        .HasForeignKey("UserMainInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserMainInfo");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.RequestVisit", b =>
                {
                    b.HasOne("HospitalApp.Domain.Entities.UserMainInfo", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Domain.Entities.UserMainInfo", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.UserAdditional", b =>
                {
                    b.HasOne("HospitalApp.Domain.Entities.UserMainInfo", "UserMainInfo")
                        .WithMany()
                        .HasForeignKey("UserMainInfoId");

                    b.Navigation("UserMainInfo");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.UserCredential", b =>
                {
                    b.HasOne("HospitalApp.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.UserMainInfo", b =>
                {
                    b.HasOne("HospitalApp.Domain.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Domain.Entities.UserCredential", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HospitalApp.Domain.Entities.Visit", b =>
                {
                    b.HasOne("HospitalApp.Domain.Entities.UserMainInfo", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Domain.Entities.MedicalCard", "MedicalCard")
                        .WithMany()
                        .HasForeignKey("MedicalCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalApp.Domain.Entities.RequestVisit", "RequestVisit")
                        .WithMany()
                        .HasForeignKey("RequestVisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("MedicalCard");

                    b.Navigation("RequestVisit");
                });
#pragma warning restore 612, 618
        }
    }
}
