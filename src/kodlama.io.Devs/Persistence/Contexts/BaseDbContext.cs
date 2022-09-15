using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> Languages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
               base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaIOConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("Languages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);

            });

            modelBuilder.Entity<Technology>(t=>
            {
                t.ToTable("Technologies").HasKey(k => k.Id);
                t.Property(p => p.Id).HasColumnName("Id");
                t.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                t.Property(p => p.Name).HasColumnName("Name");
                t.HasOne(p => p.ProgrammingLanguage);


            });

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.FirstName).HasColumnName("FirstName");
                a.Property(c => c.LastName).HasColumnName("LastName");
                a.Property(c => c.Email).HasColumnName("Email");
                a.Property(c => c.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(c => c.PasswordHash).HasColumnName("PasswordHash");
                a.Property(c => c.Status).HasColumnName("Status");
                a.Property(c => c.AuthenticatorType).HasColumnName("AuthenticatorType");

                a.HasMany(c => c.UserOperationClaims);
                a.HasMany(c => c.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.UserId).HasColumnName("UserId");
                a.Property(c => c.OperationClaimId).HasColumnName("OperationClaimId");

                a.HasOne(c => c.OperationClaim);
                a.HasOne(c => c.User);
            });



            //ProgrammingLanguage[] languageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgrammingLanguage>();


        }
    }
}
