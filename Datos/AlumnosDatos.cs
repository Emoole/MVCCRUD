using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class AlumnosDatos
    {
        //CLASE PARA CONECTARNOS A LOS PROCEDIMIENTOS ALMACENADOS.
        //metodos a utilizar
        // lista del modelo -- obtener todos los alumnos
        public List<AlumnosModel> Listar()
        {
            //referencia a la lista
            var olista = new List<AlumnosModel>();

            //Instancia a la clase de la conexion
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                //lEER EL RESULTADO
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new AlumnosModel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            Genero = dr["Genero"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])

                        });
                    }
                }
                return olista;
            }

        }

        public AlumnosModel Obtener(int Id)
        {
            //referencia a la lista
            var oAlumno = new AlumnosModel();

            //Instancia a la clase de la conexion
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_OBTENER", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                //lEER EL RESULTADO
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oAlumno.Id = Convert.ToInt32(dr["Id"]);
                        oAlumno.Nombres = dr["Nombres"].ToString();
                        oAlumno.Apellidos = dr["Apellidos"].ToString();
                        oAlumno.Genero = dr["Genero"].ToString();
                        oAlumno.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    }
                }
                return oAlumno;
            }
        }

        public bool Guardar(AlumnosModel oAlumno)
        {
            bool rpta;

            try
            {
                //Instancia a la clase de la conexion
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GUARDAR", conexion);
                    cmd.Parameters.AddWithValue("Nombres", oAlumno.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oAlumno.Apellidos);
                    cmd.Parameters.AddWithValue("Genero", oAlumno.Genero);
                    cmd.Parameters.AddWithValue("FechaRegistro", oAlumno.FechaRegistro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Editar(AlumnosModel oAlumno)
        {
            bool rpta;

            try
            {
                //Instancia a la clase de la conexion
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITAR", conexion);
                    cmd.Parameters.AddWithValue("Id", oAlumno.Id);
                    cmd.Parameters.AddWithValue("Nombres", oAlumno.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oAlumno.Apellidos);
                    cmd.Parameters.AddWithValue("Genero", oAlumno.Genero);
                    cmd.Parameters.AddWithValue("FechaRegistro", oAlumno.FechaRegistro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int Id)
        {
            bool rpta;

            try
            {
                //Instancia a la clase de la conexion
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR", conexion);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

    }
}
