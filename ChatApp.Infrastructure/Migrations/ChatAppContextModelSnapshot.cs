﻿// <auto-generated />
using System;
using ChatApp.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatApp.Infrastructure.Migrations
{
    [DbContext(typeof(ChatAppContext))]
    partial class ChatAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChatApp.Domain.Entities.ChatRoom", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ChatRooms");
                });

            modelBuilder.Entity("ChatApp.Domain.Entities.ChatRoomMember", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("MemberId");

                    b.HasIndex("RoomId");

                    b.ToTable("ChatRoomMembers");
                });

            modelBuilder.Entity("ChatApp.Domain.Entities.Member", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activated")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ChatApp.Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Seen")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SeenTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SendedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("ChatRoomId");

                    b.HasIndex("SendedById");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChatApp.Domain.Entities.ChatRoomMember", b =>
                {
                    b.HasOne("ChatApp.Domain.Entities.Member", "Member")
                        .WithMany("ChatRooms")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatApp.Domain.Entities.ChatRoom", "ChatRoom")
                        .WithMany("RoomMembers")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatRoom");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ChatApp.Domain.Entities.Message", b =>
                {
                    b.HasOne("ChatApp.Domain.Entities.ChatRoom", "ChatRoom")
                        .WithMany("RoomMessages")
                        .HasForeignKey("ChatRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatApp.Domain.Entities.Member", "Member")
                        .WithMany("MemberMessages")
                        .HasForeignKey("SendedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatRoom");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ChatApp.Domain.Entities.ChatRoom", b =>
                {
                    b.Navigation("RoomMembers");

                    b.Navigation("RoomMessages");
                });

            modelBuilder.Entity("ChatApp.Domain.Entities.Member", b =>
                {
                    b.Navigation("ChatRooms");

                    b.Navigation("MemberMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
