﻿using FINAL_PROJECT_Meow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FINAL_PROJECT_Meow.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ticket> Tickets  { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base. OnModelCreating(builder);

            builder.Entity<Comment>()
                .HasOne(c =>  c.CreatedBy)
                .WithMany()
                .HasForeignKey(c => c.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comment>()
               .HasOne(c => c.Ticket)
               .WithMany()
               .HasForeignKey(c => c.TicketId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
                .HasOne(c => c.CreatedBy)
                .WithMany()
                .HasForeignKey(c => c.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
