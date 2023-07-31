using Microsoft.AspNetCore.Mvc;

namespace TP06_Elecciones_Farina_RuizBarrea.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.ListaPartido = BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido){
        ViewBag.detallePartido = BD.VerInfoPartido(idPartido);
        ViewBag.partidoCandidato = BD.ListarCandidatos(idPartido);
        return View("DetallePartido");
    }
    public IActionResult VerDetalleCandidato(int idCandidato){
        ViewBag.detalleCandidato = BD.VerInfoCandidato(idCandidato);
        return View("DetalleCandidato");
    }
    public IActionResult AgregarCandidato(int idPartido){       
        ViewBag.ListaIdPartidos = idPartido;
        return View("CandidatoFormulario");
    }
    public IActionResult AgregarPartido(){
        return View("PartidoFormulario");
    }
    [HttpPost]
    public IActionResult GuardarCandidato(Candidato candidato){
        BD.AgregarCandidato(candidato);
        ViewBag.detallePartido = BD.VerInfoPartido(candidato.IdPartido);
        ViewBag.detalleCandidato = BD.ListarCandidatos(candidato.IdPartido);
        return RedirectToAction("VerDetallePartido", new { idPartido = candidato.IdPartido});
    }
    [HttpPost]
    public IActionResult GuardarPartido(Partido partido){
        BD.AgregarPartido(partido);
        ViewBag.ListaPartido = BD.ListarPartidos();
        return View("Index");
    }
    public IActionResult EliminarPartido(int idPartido){
        BD.EliminarPartido(idPartido);
        ViewBag.ListaPartido = BD.ListarPartidos();
        return View("Index");
    }
    public IActionResult EliminarCandidato(int idCandidato, int idPartido){
        BD.EliminarCandidato(idCandidato);
        return RedirectToAction("VerDetallePartido", new { idPartido = idPartido});
    }
    public IActionResult Elecciones(){
        return View("EleccionesInfo");
    }
    public IActionResult Creditos(){
        return View();
    }
}

