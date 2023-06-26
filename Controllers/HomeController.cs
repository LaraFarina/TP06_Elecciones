using Microsoft.AspNetCore.Mvc;

namespace TP_06_RuizBarrea_Farina.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    { 
        ViewBag.listaPartidos = BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido)
    { 
        ViewBag.detallePartido = BD.VerInfoPartido(idPartido);
        return View("VerDetallePartido");
    }
    public IActionResult VerDetalleCandidato(int idCandidato)
    { 
        ViewBag.detalleCandidato = BD.VerInfoCandidato(idCandidato);
        return View("VerDetalleCandidato");
    }
    public IActionResult AgregarCandidato(int idPartido)
    { 
        ViewBag.idPartido = idPartido;
        return View("CargarCandidato");
    }

    [HttpPost]
   /* public IActionResult GuardarCandidato(Candidato candidato)
    { 
        BD.AgregarCandidato(candidato);
        return RedirectToAction("VerDetallePartido", new { idPartido = candidato.IdPartido});
    } */
    public IActionResult EliminarCandidato(int idCandidato, int IdPartido)
    { 
        BD.EliminarCandidato(idCandidato);
        return RedirectToAction("VerDetallePartido", new { dPartido = IdPartido});
    }
    public IActionResult Elecciones()
    { 
        return View("Elecciones");
    }
    public IActionResult Creditos()
    { 
        return View("Creditos");
    }
}