using System.Data.SqlClient;
using Dapper;

class BD
{
    private static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";

    public static void AgregarCandidato(Candidato candidato)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Candidato(IDCandidato, IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@pIDCandidato, @pIdPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
            db.Execute(sql, new { pIDCandidato = candidato.IdCandidato, pIdPartido = candidato.IdPartido, pApellido = candidato.Apellido, pNombre = candidato.Nombre, pFechaNacimiento = candidato.FechaNacimiento, pFoto = candidato.Foto, pPostulacion = candidato.Postulacion });
        }
    }
    public static void EliminarCandidato(int idCandidato)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Candidato WHERE idCandidato = @pidCandidato";
            db.Execute(sql, new { pidCandidato = idCandidato });
        }
    }
    public static Partido VerInfoPartido(int idPartido)
    {
        Partido partido = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido WHERE IdPartido = @pIdPartido";
            partido = db.QueryFirstOrDefault<Partido>(sql, new { pIdPartido = idPartido });
        }
        return partido;
    }
    public static Candidato VerInfoCandidato(int idCandidato)
    {
        Candidato candidato = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE IdCandidato = @pIdCandidato";
            candidato = db.QueryFirstOrDefault<Candidato>(sql, new { pIdCandidato = idCandidato });
        }
        return candidato;
    }
    public static List<Partido> ListarPartidos()
    {
        List<Partido> listaPartidos = new List<Partido>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido";
            listaPartidos = db.Query<Partido>(sql).ToList();
        }
        return listaPartidos;
    }
    public static List<Candidato> ListarCandidatos()
    {
        List<Candidato> listaCandidatos = new List<Candidato>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido";
            listaCandidatos = db.Query<Candidato>(sql).ToList();
        }
        return listaCandidatos;
    }
}

