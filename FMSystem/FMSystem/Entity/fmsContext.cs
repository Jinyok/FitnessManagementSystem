using System;
using FMSystem.Entity.fms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FMSystem.Entity
{
    public partial class fmsContext : DbContext
    {

        public fmsContext(DbContextOptions<fmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Instructs> Instructs { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Takes> Take { get; set; }

        public virtual DbSet<CourseArrangement> CourseArrangement { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        //optionsBuilder.UseMySql("server=localhost;database=fms;user=root;password=;treattinyasboolean=true", x => x.ServerVersion("8.0.19-mysql"));
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.ToTable("coach");

                //entity.Property(e => e.CoachId).HasColumnName("CoachID");

                //entity.Property(e => e.Email)
                //    .HasColumnType("varchar(30)")
                //    //.HasCharSet("utf8mb4")
                //    //.HasCollation("utf8mb4_0900_ai_ci")
                //    ;

                //entity.Property(e => e.Name)
                //    .IsRequired()
                //    .HasColumnType("varchar(45)")
                //    //.HasCharSet("utf8mb4")
                //    //.HasCollation("utf8mb4_0900_ai_ci")
                //    ;
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                //entity.Property(e => e.CourseId).HasColumnName("CourseID");

                //entity.Property(e => e.Title)
                //    .HasColumnType("varchar(45)")
                //    //.HasCharSet("utf8mb4")
                //    //.HasCollation("utf8mb4_0900_ai_ci")
                //    ;
            });

            modelBuilder.Entity<Instructs>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.CoachId })
                    .HasName("PRIMARY");

                entity.ToTable("instructs");

                entity.HasIndex(e => e.CoachId)
                    .HasName("instruct_CoachID_idx");

                //entity.Property(e => e.MemberId).HasColumnName("MemberID");

                //entity.Property(e => e.CoachId).HasColumnName("CoachID");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Instructs)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    //.HasConstraintName("instruct_CoachID")
                    ;

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Instructs)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    //.HasConstraintName("instruct_MemberID")
                    ;
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                //entity.Property(e => e.MemberId).HasColumnName("MemberID");

                //entity.Property(e => e.Name)
                //    .HasColumnType("varchar(45)")
                //    //.HasCharSet("utf8mb4")
                //    //.HasCollation("utf8mb4_0900_ai_ci")
                ;
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("section");

                entity.HasIndex(e => e.CourseId)
                    .HasName("section_CourseID_idx");

                //entity.Property(e => e.SectionId).HasColumnName("SectionID");

                //entity.Property(e => e.CourseId).HasColumnName("CourseID");

                //entity.Property(e => e.EndDate).HasColumnType("date");

                //entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Section)
                    .HasForeignKey(d => d.CourseId)
                    //.HasConstraintName("section_CourseID")
                    ;

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.CourseId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                //entity.Property(e => e.Userid)
                //    //.HasColumnName("userid")
                //    .HasColumnType("varchar(20)")
                //    //.HasCharSet("utf8mb4")
                //    //.HasCollation("utf8mb4_0900_ai_ci")
                //    ;

                //entity.Property(e => e.CreateTime)
                //    //.HasColumnName("create_time")
                //    .HasColumnType("date");

                //entity.Property(e => e.Password)
                //    .IsRequired()
                //    //.HasColumnName("password")
                //    //.HasColumnType("varchar(100)")
                //    //.HasCharSet("utf8mb4")
                //    //.HasCollation("utf8mb4_0900_ai_ci")
                //    ;
            });
            modelBuilder.Entity<Takes>(entity =>
            {
                entity.ToTable("takes");
                entity.HasKey(e => new { e.MemberId, e.SectionId })
                    .HasName("PRIMARY");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<CourseArrangement>(entity =>
            {
                entity.ToTable("coursearrangement");
                entity.HasKey(e => new { e.CourseId, e.CourseNo })
                    .HasName("PRIMARY");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseArrangement)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.CourseArrangement)
                    .HasForeignKey(d => d.CoachId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
