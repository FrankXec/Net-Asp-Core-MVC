using HolaMundo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HolaMundo.Controllers;

public class EscuelaController : Controller
{
    private EscuelaContext _context;
    public EscuelaController(EscuelaContext context){
        _context = context;
    }
    /*public IActionResult Index()
    {
        var escuela = new Escuela();
        escuela.UniqueId = "A-51";
        escuela.Nombre = "Frank's";
        escuela.AnioFundacion = 2020;

        ViewBag.Valor = "Hola Mundo";
        return View(escuela);
    }*/
    public IActionResult Index()
    {
        var escuela = _context.Escuelas.FirstOrDefault();
        return View(escuela);
    }

    
}