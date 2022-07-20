using Microsoft.EntityFrameworkCore;

namespace HolaMundo.Models;

public class EscuelaContext : DbContext 
{
    public DbSet<Escuela> Escuelas { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }

    public EscuelaContext(DbContextOptions<EscuelaContext> options):base(options){

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        var escuela = new Escuela();
        escuela.Id = "A-51";
        escuela.Nombre = "Frank's";
        escuela.AnioFundacion = 2020;
        modelBuilder.Entity<Escuela>().HasData(
            escuela
        );
        modelBuilder.Entity<Alumno>().HasData(
            new Alumno(Guid.NewGuid().ToString(),"Francisco","Xec"),
            new Alumno(Guid.NewGuid().ToString(),"Lionel","Jacinto"),
            new Alumno(Guid.NewGuid().ToString(),"Narciso","Xec"),
            new Alumno(Guid.NewGuid().ToString(),"Odilia","Tun")
        );
    }
}