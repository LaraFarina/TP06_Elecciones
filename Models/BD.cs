using System.Data.SqlClient;
using Dapper;

namespace TP06_Elecciones_Farina_RuizBarrea.Models;

public class BD {
     private static string ConnectionString = @"Server=localhost;DataBase=Elecciones;Trusted_Connection=True;";
    private static List<Partido> ListPartidos = new List<Partido>();
    private static List<Candidato> ListCandidatos = new List<Candidato>();
    public static void AgregarCandidato(Candidato candidato){
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "INSERT INTO Candidato(IdPartido,Apellido,Nombre,FechaNacimiento,Foto,Postulacion) VALUES (@pIdPartido,@pApellido,@pNombre,@pFechaNacimiento,@pFoto,@pPostulacion)";
            db.Execute(sql, new { pIdPartido = candidato.IdPartido, pApellido = candidato.Apellido, pNombre = candidato.Nombre, pFechaNacimiento = candidato.FechaNacimiento, pFoto = candidato.Foto, pPostulacion = candidato.Postulacion});
        }
    }
    public static int EliminarCandidato(int idCandidato)
    {     
        int regEliminado = 0;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "DELETE FROM Candidato WHERE IdCandidato = @pidCandidato";
            regEliminado = db.Execute(sql, new { pidCandidato = idCandidato });
        }
        return regEliminado;
    }
    public static void AgregarPartido(Partido partido){
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "INSERT INTO Partido(Nombre,Logo,SitioWeb,FechaFundacion,CantidadDiputados,CantidadSenadores) VALUES (@pNombre,@pLogo,@pSitioWeb,@pFechaFundacion,@pCantidadDiputados,@pCantidadSenadores)";
            db.Execute(sql, new {pNombre = partido.Nombre, pLogo = partido.Logo, pSitioWeb = partido.SitioWeb, pFechaFundacion = partido.FechaFundacion, pCantidadDiputados = partido.CantidadDiputados, pCantidadSenadores = partido.CantidadSenadores});
        }
    }
    public static int EliminarPartido(int idPartido)
    {
        int regEliminado=0;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "DELETE FROM Partido WHERE IdPartido = @pidPartido";
            string sql1= "DELETE FROM Candidato WHERE IdPartido = @pidPartido";
            regEliminado = db.Execute(sql, new { pidPartido = idPartido });
            db.Execute(sql1, new {pidPartido = idPartido});
        }
        return regEliminado;
    }
    public static Partido VerInfoPartido(int idPartido){
        Partido infoPartido = null;
         using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Partido WHERE IdPartido = @idPartido";
            infoPartido = db.QueryFirstOrDefault<Partido>(sql, new{IdPartido=idPartido});
        }
        return infoPartido;
    }
    public static Candidato VerInfoCandidato(int idCandidato){
        Candidato infoCandidato = null;
         using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE IdCandidato = @idCandidato";
            infoCandidato = db.QueryFirstOrDefault<Candidato>(sql, new{IdCandidato=idCandidato});
        }
        return infoCandidato;
    }
    public static List<Partido> ListarPartidos()
    {
        List <Partido> ListPartidos = null;
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "SELECT * FROM Partido";
            ListPartidos = db.Query<Partido>(sql).ToList();
        }
        return ListPartidos;
    }
    public static List<Candidato> ListarCandidatos(int idPartido)
    {
       List <Candidato> ListCandidatos = new List<Candidato>();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE IdPartido = @IdPartido";
            ListCandidatos = db.Query<Candidato>(sql, new{IdPartido=idPartido}).ToList();
        }
        return ListCandidatos;
    }
}