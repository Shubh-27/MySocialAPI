using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MySocialAppAPI.TenantDB
{
    public partial class MySocialAppDBContext : DbContext
    {
        public MySocialAppDBContext()
        {
        }

        public MySocialAppDBContext(DbContextOptions<MySocialAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<MySocial> MySocials { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.FriendFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friend_MySocial");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.FriendToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friend_MySocial1");
            });

            modelBuilder.Entity<MySocial>(entity =>
            {
                entity.Property(e => e.AccountCreated).HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ModifiedDateTime).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_MySocial");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
