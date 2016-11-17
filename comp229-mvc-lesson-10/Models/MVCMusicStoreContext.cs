namespace comp229_mvc_lesson_10.Models {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MVCMusicStoreContext : DbContext {
        public MVCMusicStoreContext()
            : base("name=MVCMusicStoreConnection") {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Album>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Albums)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Albums)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);
        }
    }
}
