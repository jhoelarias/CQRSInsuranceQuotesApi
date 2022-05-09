namespace Coterie.Data
{
    using Domain.Enums;
    using Domain.Extensions;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class CoterieContext : DbContext, ICoterieContext
    {
        public DbSet<Business> Businesses { get; set; }
        public DbSet<State> States { get; set; }

        public CoterieContext(DbContextOptions<CoterieContext> options) : base(options)
        {
        }

        public CoterieContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => e.BusinessId);
                entity.Property(e => e.BusinessId);
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.Factor);

                entity.HasData(
                    new Business { BusinessId = 1, Name = BusinessEnum.Architect.ToString(), Factor = 1 },
                    new Business { BusinessId = 2, Name = BusinessEnum.Plumber.ToString(), Factor = 0.5 },
                    new Business { BusinessId = 3, Name = BusinessEnum.Programmer.ToString(), Factor = 1.25 }
                    );
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.StateId);
                entity.Property(e => e.StateId);
                entity.Property(e => e.Name).HasMaxLength(500);
                entity.Property(e => e.Factor);

                entity.HasData(
                    new State { StateId = 1, Name = StatesEnum.OH.GetDescription(), Code = StatesEnum.OH.ToString(), Factor = 1 },
                    new State { StateId = 2, Name = StatesEnum.FL.GetDescription(), Code = StatesEnum.FL.ToString(), Factor = 1.2 },
                    new State { StateId = 3, Name = StatesEnum.TX.GetDescription(), Code = StatesEnum.TX.ToString(), Factor = 0.943 }
                );
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}