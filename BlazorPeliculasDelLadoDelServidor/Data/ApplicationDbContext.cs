using BlazorPeliculasDelLadoDelServidor.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculasDelLadoDelServidor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneroPelicula>().HasKey(x => new { x.GeneroId, x.PeliculaId });
            modelBuilder.Entity<PeliculaActor>().HasKey(x => new { x.PeliculaId, x.PersonaId });

            var roleAdminId = "822caaee-20b6-4448-8542-ea4cee66400f";
            var usuarioAdminId = "6215017a-5bcd-4197-bec5-390838f8c5b6";

            var roleAdmin = new IdentityRole()
            { Id = roleAdminId, Name = "admin", NormalizedName = "admin" };

            var hasher = new PasswordHasher<IdentityUser>();

            var usuarioAdmin = new IdentityUser()
            {
                Id = usuarioAdminId,
                Email = "kike@gmail.com",
                UserName = "kike@gmail.com",
                NormalizedUserName = "kike@gmail.com",
                NormalizedEmail = "kike@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "AQAAAAIAAYagAAAAEAiYPHEsWpyjh7VQS0zgpYlX9YKf41fNnIMZjXAAYZVO2KZ8PPwAvsXcjld4Uc/EKg==")
            };

            //modelBuilder.Entity<IdentityUser>().HasData(usuarioAdmin);

            //modelBuilder.Entity<IdentityUserRole<string>>()
            //    .HasData(new IdentityUserRole<string>() { RoleId = roleAdminId, UserId = usuarioAdminId });

            modelBuilder.Entity<IdentityRole>().HasData(roleAdmin);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GeneroPelicula> GenerosPeliculas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }
        public DbSet<VotoPelicula> VotosPeliculas { get; set; }
    }
}