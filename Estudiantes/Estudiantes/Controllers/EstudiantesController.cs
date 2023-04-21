using Estudiantes.Data;
using Estudiantes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes.Controllers
{
    [ApiController]
    [Route("api/estudiantes")]
    public class EstudiantesController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<MEstudiantes>>> Get()
        {
            DEstudiantes funcion = new();
            List<MEstudiantes> list = await funcion.GetAllStudents();
            return list;
        }
        [HttpPost]
        public async Task Set([FromBody] MEstudiantes estudiantes)
        {
            DEstudiantes funcion = new();
            await funcion.InsertStudent(estudiantes);
        }
        /// <summary>
        /// Controller para modificar informacion de un estudiante
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="estudiantes"></param>
        /// <returns></returns>
        [HttpPut("{documento}")]
        public async Task<ActionResult> Put(int documento, [FromBody] MEstudiantes estudiantes)
        {
            DEstudiantes funcion = new();
            estudiantes.documento = documento;
            await funcion.UpdateStudent(estudiantes);
            return NoContent();
        }
        [HttpDelete("{documento}")]
        public async Task<ActionResult> Delete(int documento)
        {
            DEstudiantes funcion = new();
            MEstudiantes document = new()
            {
                documento = documento
            };
            await funcion.DeleteStudent(document);
            return NoContent();
        }
    }
}
