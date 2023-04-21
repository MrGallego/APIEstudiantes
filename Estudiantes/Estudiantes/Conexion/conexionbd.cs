using Microsoft.Extensions.Configuration;

namespace Estudiantes.Conexion
{
    public class conexionbd
    {
        private string connectionString = string.Empty;
        public conexionbd()
        {
            var constr = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            connectionString = constr.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public string cadenaSQL()
        {
            return connectionString;
        }
    }
}
