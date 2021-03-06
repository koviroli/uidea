﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UIdea.Models;

namespace UIdea.Migrations.Issue
{
    [DbContext(typeof(IssueContext))]
    partial class IssueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UIdea.Models.Issue", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<int>("IssueType");

                    b.Property<string>("Name");

                    b.Property<int>("Priority");

                    b.Property<string>("ProjectID");

                    b.Property<int>("Reward");

                    b.Property<int>("RewardType");

                    b.Property<DateTime>("Updated");

                    b.HasKey("ID");

                    b.ToTable("Issue");
                });
#pragma warning restore 612, 618
        }
    }
}
