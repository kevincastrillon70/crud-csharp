using System.Data.SqlClient;
namespace CrudClientes.Datos
{
    public class Conexion
    {
        private string stringSql = string.Empty;

        public Conexion() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            stringSql = builder.GetSection("ConnectionStrings:stringSQL").Value;   
            
        }

        public string GetStringSql()
        {
            return stringSql;
        }
    }
}
