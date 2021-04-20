using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using apsWeb.Models;

#nullable disable

namespace apsWeb.Data
{
    public partial class ChatboxDbContext : DbContext
    {
        public ChatboxDbContext()
        {
        }

        public ChatboxDbContext(DbContextOptions<ChatboxDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<DuoChannel> DuoChannels { get; set; }
        public virtual DbSet<MessageTable> MessageTables { get; set; }
        public virtual DbSet<MultiChannel> MultiChannels { get; set; }
        public virtual DbSet<UserChannel> UserChannels { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CHATBOX");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.Property(e => e.ChannelId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DuoChannel>(entity =>
            {
                entity.HasOne(d => d.Channel)
                    .WithOne(p => p.DuoChannel)
                    .HasForeignKey<DuoChannel>(d => d.ChannelId)
                    .HasConstraintName("FK_DUO_CHANNEL_CHANNEL_ID");
            });

            modelBuilder.Entity<MessageTable>(entity =>
            {
                entity.HasKey(e => new { e.MessageId, e.UserLogin, e.ChannelId });

                entity.Property(e => e.MessageId).ValueGeneratedOnAdd();

                entity.Property(e => e.UserLogin).IsUnicode(false);

                entity.Property(e => e.Content).IsUnicode(false);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.MessageTables)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK_MESSAGE_TABLE_CHANNEL_ID");

                entity.HasOne(d => d.UserLoginNavigation)
                    .WithMany(p => p.MessageTables)
                    .HasForeignKey(d => d.UserLogin)
                    .HasConstraintName("FK_MESSAGE_USER_LOGIN");
            });

            modelBuilder.Entity<MultiChannel>(entity =>
            {
                entity.Property(e => e.ManagerId).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Channel)
                    .WithOne(p => p.MultiChannel)
                    .HasForeignKey<MultiChannel>(d => d.ChannelId)
                    .HasConstraintName("FK_MULTI_CHANNEL_CHANNEL_ID");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.MultiChannels)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_MULTI_CHANNEL_MANANGER_ID");
            });

            modelBuilder.Entity<UserChannel>(entity =>
            {
                entity.HasKey(e => new { e.ChannelId, e.UserLogin });

                entity.Property(e => e.UserLogin).IsUnicode(false);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.UserChannels)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("PK_USER_CHANNEL_CHANNEL_ID");

                entity.HasOne(d => d.UserLoginNavigation)
                    .WithMany(p => p.UserChannels)
                    .HasForeignKey(d => d.UserLogin)
                    .HasConstraintName("PK_USER_CHANNEL_USER_ID");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.Property(e => e.UserLogin).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
