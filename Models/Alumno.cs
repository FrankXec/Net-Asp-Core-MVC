namespace HolaMundo.Models;

public class Alumno
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    public Alumno(string Id,string Nombre,string Apellido)
    {
        this.Id =  Id;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
    }
}