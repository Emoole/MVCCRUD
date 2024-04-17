using System.Data.SqlClient;
namespace CRUDCORE.Datos
{
    public class Conexion
    {
        private string cadenaSQL= string.Empty;

        public Conexion()
        {
            // var es utilizado para crear cualquier tipo de variable, se convierte en cualquier tipo de dato.
            // Obtenemos la cadena de conexion del appsettings
            var biulder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL= biulder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        //METODO PARA DEVOLVER LA CADENA
        public string getCadenaSQL() 
        {  
            return cadenaSQL; 
        }

        
    }
}
