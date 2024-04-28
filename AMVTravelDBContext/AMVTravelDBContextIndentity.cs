using AMVTravelModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMVTravelDBContext
{
    public class AMVTravelDBContextIndentity : IdentityDbContext<Client>
    {
        public AMVTravelDBContextIndentity (DbContextOptions<AMVTravelDBContextIndentity> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>(entity => { entity.ToTable(name: "Clients"); });
            builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
            builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable(name: "ClientRoles"); });
            builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable(name: "ClientClaims"); });
            builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable(name: "ClientLogins"); });
            builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable(name: "ClientTokens"); });
            builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable(name: "RoleClaims"); });

            builder.Entity<Booking>()
                .HasOne(booking => booking.Tour)
                .WithMany(tour=> tour.Bookings)
                .HasForeignKey(booking=> booking.IdTour)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Booking>()
                .HasOne(booking=> booking.Client)
                .WithMany(client=> client.Bookings)
                .HasForeignKey(booking=> booking.IdClient)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Client>()
                .HasMany(client => client.Bookings)
                .WithOne(booking => booking.Client)
                .HasForeignKey(booking => booking.IdClient)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Tour>()
                .HasMany(tour => tour.Bookings)
                .WithOne(booking => booking.Tour)
                .HasForeignKey(booking => booking.IdTour)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Booking> Bookings {  get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}