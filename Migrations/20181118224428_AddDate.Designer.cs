﻿// <auto-generated />
using System;
using MMMarketTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MMMarketTracker.Migrations
{
    [DbContext(typeof(MMMarketTrackerContext))]
    [Migration("20181118224428_AddDate")]
    partial class AddDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("MMMarketTrader.Models.MarketSaleRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Item");

                    b.Property<long>("Price");

                    b.HasKey("Id");

                    b.ToTable("MarketSaleRecord");
                });
#pragma warning restore 612, 618
        }
    }
}
