﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context :IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-A7U7GT0\\SQLEXPRESS;database=CoreBlogDbMH;integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(x => x.HomeTeam)
                .WithMany(y => y.HomeMatches)
                .HasForeignKey(z => z.HomeTeamsId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Match>()
               .HasOne(x => x.GuesTime)
               .WithMany(y => y.AwayMatches)
               .HasForeignKey(z => z.GuesteamsId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
             .HasOne(x => x.SenderUser)
             .WithMany(y => y.WriterSender)
             .HasForeignKey(z => z.SenderId)
             .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Message2>()
             .HasOne(x => x.ReciverUser)
             .WithMany(y => y.WriterReceiver)
             .HasForeignKey(z => z.ReceiverId)
             .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
            //HomeMatches-->WriterSender
            //AwayMatches-->WriterReceiver

            //HomeTeam-->SenderUser
            //GuesTime-->ReciverUser
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLatter> NewsLatters { get; set; }
        public DbSet<BlogRaytingA> BlogRaytingAs { get; set; }
        public DbSet<Natification> Natifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
