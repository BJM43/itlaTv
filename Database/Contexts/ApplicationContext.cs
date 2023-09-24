using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<TvSerie> TvSeries { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            #region Tables
            modelBuilder.Entity<TvSerie>().ToTable("TvSeries");
            modelBuilder.Entity<Producer>().ToTable("Producers");
            modelBuilder.Entity<Gender>().ToTable("Genders");
            #endregion

            #region Primary keys
            modelBuilder.Entity<TvSerie>().HasKey(tvSerie => tvSerie.Id);
            modelBuilder.Entity<Producer>().HasKey(producer => producer.Id);
            modelBuilder.Entity<Gender>().HasKey(gender => gender.Id);
            #endregion

            #region Relationships
            modelBuilder.Entity<Producer>()
                .HasMany<TvSerie>(producer => producer.TvSeries)
                .WithOne(tvSerie => tvSerie.Producer)
                .HasForeignKey(tvSerie => tvSerie.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Gender>()
                .HasMany<TvSerie>(gender => gender.TvSeries)
                .WithOne(tvSerie => tvSerie.Gender)
                .HasForeignKey(tvSerie => tvSerie.PrimaryGenderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Gender>()
                .HasMany<TvSerie>(gender => gender.TvSeries)
                .WithOne(tvSerie => tvSerie.Gender)
                .HasForeignKey(tvSerie => tvSerie.SecondaryGenderId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Property configurations

            #region TvSerie
            modelBuilder.Entity<TvSerie>().Property(ts => ts.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<TvSerie>().Property(ts => ts.Link)
                .IsRequired();

            modelBuilder.Entity<TvSerie>().Property(ts => ts.ImgLink)
                .IsRequired();
            #endregion

            #region Producer
            modelBuilder.Entity<Producer>().Property(ts => ts.Name)
                .IsRequired()
                .HasMaxLength(100);
            #endregion

            #region Gender
            modelBuilder.Entity<Gender>().Property(ts => ts.Name)
                .IsRequired()
                .HasMaxLength(100);
            #endregion

            #endregion
        }
    }
}
