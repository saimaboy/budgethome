namespace BudgetHomeDesign.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<FirstFloorclassical> FirstFloorclassicals { get; set; }
        public virtual DbSet<FirstFloorModern> FirstFloorModerns { get; set; }
        public virtual DbSet<FoundationOnly> FoundationOnlies { get; set; }
        public virtual DbSet<MaterialClassic> MaterialClassics { get; set; }
        public virtual DbSet<MaterialModern> MaterialModerns { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FirstFloorclassical>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FirstFloorclassical>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FirstFloorModern>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FirstFloorModern>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FoundationOnly>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FoundationOnly>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MaterialClassic>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialClassic>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MaterialModern>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialModern>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Plan>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Plan>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Plan>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Plan>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Plan>()
                .Property(e => e.Size)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Plan>()
                .Property(e => e.PictureUrl)
                .IsUnicode(false);
        }
    }
}
