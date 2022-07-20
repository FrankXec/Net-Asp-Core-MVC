using HolaMundo.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.Controllers;

public class AlumnoController : Controller
{
    private EscuelaContext _context;
    public AlumnoController(EscuelaContext context){
        _context = context;
    }
    /*public IActionResult Index()
    {
        var alumno = new Alumno(Guid.NewGuid().ToString(),"Francisco","Xec");
        return View(alumno);
        //return View("Alumnos",alumno);  -->sirve para indicarle que vista va a renderizar
    }

    public IActionResult Alumnos()
    {
        var lista = new List<Alumno>(){
            new Alumno(Guid.NewGuid().ToString(),"Francisco","Xec"),
            new Alumno(Guid.NewGuid().ToString(),"Lionel","Jacinto"),
            new Alumno(Guid.NewGuid().ToString(),"Narciso","Xec"),
            new Alumno(Guid.NewGuid().ToString(),"Odilia","Tun")
        };
        return View(lista);
    }*/
    public IActionResult Index()
    {
        var alumno = new Alumno(Guid.NewGuid().ToString(),"Francisco","Xec");
        return View(alumno);
        //return View("Alumnos",alumno);  -->sirve para indicarle que vista va a renderizar
    }

    public IActionResult Alumnos()
    {
        var lista = _context.Alumnos;
        return View(lista);
    }
}