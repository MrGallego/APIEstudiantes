using Estudiantes.Conexion;
using Estudiantes.Models;
using System.Data;
using System.Data.SqlClient;

namespace Estudiantes.Data
{
    public class DEstudiantes
    {
        private readonly conexionbd cn = new();
        /// <summary>
        /// Metodo para consultar todos los estudiantes
        /// </summary>
        /// <returns></returns>
        public async Task<List<MEstudiantes>> GetAllStudents()
        {
            List<MEstudiantes> list = new();
            using (SqlConnection sql = new(cn.cadenaSQL()))
            {
                using SqlCommand cmd = new("mostrarEstudiantes", sql);
                await sql.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                using SqlDataReader item = await cmd.ExecuteReaderAsync();
                while (await item.ReadAsync())
                {
                    MEstudiantes mestudiantes = new()
                    {
                        id = (int)item["id"],
                        documento = (int)item["documento"],
                        nombre = (string)item["nombre"],
                        edad = (int)item["edad"]
                    };
                    list.Add(mestudiantes);
                }
            }
            return list;
        }
        /// <summary>
        /// Metodo para insertar estudiantes
        /// </summary>
        /// <param name="estudiantes"></param>
        /// <returns></returns>
        public async Task InsertStudent(MEstudiantes estudiantes)
        {

            using SqlConnection sql = new(cn.cadenaSQL());
            using SqlCommand cmd = new("insertEstudiante", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            _ = cmd.Parameters.AddWithValue("@documento", estudiantes.documento);
            _ = cmd.Parameters.AddWithValue("@nombre", estudiantes.nombre);
            _ = cmd.Parameters.AddWithValue("@edad", estudiantes.edad);
            await sql.OpenAsync();
            _ = await cmd.ExecuteNonQueryAsync();

        }
        /// <summary>
        /// Metodo para modificar un estudiante
        /// </summary>
        /// <param name="estudiantes"></param>
        /// <returns></returns>
        public async Task UpdateStudent(MEstudiantes estudiantes)
        {

            using SqlConnection sql = new(cn.cadenaSQL());
            using SqlCommand cmd = new("updateEstudiante", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            _ = cmd.Parameters.AddWithValue("@documento", estudiantes.documento);
            _ = cmd.Parameters.AddWithValue("@nombre", estudiantes.nombre);
            _ = cmd.Parameters.AddWithValue("@edad", estudiantes.edad);
            await sql.OpenAsync();
            _ = await cmd.ExecuteNonQueryAsync();

        }
        public async Task DeleteStudent(MEstudiantes estudiante)
        {

            using SqlConnection sql = new(cn.cadenaSQL());
            using SqlCommand cmd = new("deleteEstudiante", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            _ = cmd.Parameters.AddWithValue("@documento", estudiante.documento);
            await sql.OpenAsync();
            _ = await cmd.ExecuteNonQueryAsync();

        }
    }
}
