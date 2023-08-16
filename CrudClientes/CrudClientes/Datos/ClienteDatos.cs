using CrudClientes.Models;
using System.Data.SqlClient;
using System.Data;
namespace CrudClientes.Datos
{
    public class ClienteDatos
    {

        public List<ClienteModel> Listar()
        {
            var lista = new List<ClienteModel>();

            var cnx = new Conexion();

            using (var conexion = new SqlConnection(cnx.GetStringSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("listarClientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {
                    while (dr.Read())
                    {
                        lista.Add(new ClienteModel() {
                            idCli = Convert.ToInt32(dr["idCli"]),
                            nombre = dr["nombre"].ToString(),
                            email = dr["email"].ToString(),
                            direccion = dr["direccion"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            cedula = dr["cedula"].ToString(),
                            fecha_nac = dr["fecha_nac"].ToString(),
                            estado = Convert.ToInt32(dr["estado"]),

                        });
                    }
                }
            }
            return lista;
        }

        public ClienteModel Obtener(int idCli)
        {
            var cliente = new ClienteModel();

            var cnx = new Conexion();

            using (var conexion = new SqlConnection(cnx.GetStringSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("ObtenerCliente", conexion);
                cmd.Parameters.AddWithValue("idCli", idCli);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cliente.idCli = Convert.ToInt32(dr["idCli"]);
                        cliente.nombre = dr["nombre"].ToString();
                        cliente.email = dr["email"].ToString();
                        cliente.direccion = dr["direccion"].ToString();
                        cliente.telefono = dr["telefono"].ToString();
                        cliente.cedula = dr["cedula"].ToString();
                        cliente.fecha_nac = dr["fecha_nac"].ToString();
                        cliente.estado = Convert.ToInt32(dr["estado"]);
                    }
                }
            }
            return cliente;
        }

        public bool Guardar(ClienteModel cliente)
        {
            bool respuesta;

            try
            {

                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.GetStringSql()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("guardarCliente", conexion);
                    cmd.Parameters.AddWithValue("nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("email", cliente.email);
                    cmd.Parameters.AddWithValue("direccion", cliente.direccion);
                    cmd.Parameters.AddWithValue("telefono", cliente.telefono);
                    cmd.Parameters.AddWithValue("cedula", cliente.cedula);
                    cmd.Parameters.AddWithValue("fecha_nac", cliente.fecha_nac);
                    cmd.Parameters.AddWithValue("estado", cliente.estado);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta=false;
                
            }

            return respuesta;
        }

        public bool Editar(ClienteModel cliente)
        {
            bool respuesta;

            try
            {

                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.GetStringSql()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("editCliente", conexion);
                    cmd.Parameters.AddWithValue("idCli", cliente.idCli);
                    cmd.Parameters.AddWithValue("nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("email", cliente.email);
                    cmd.Parameters.AddWithValue("direccion", cliente.direccion);
                    cmd.Parameters.AddWithValue("telefono", cliente.telefono);
                    cmd.Parameters.AddWithValue("cedula", cliente.cedula);
                    cmd.Parameters.AddWithValue("fecha_nac", cliente.fecha_nac);
                    cmd.Parameters.AddWithValue("estado", cliente.estado);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;

            }

            return respuesta;
        }

        public bool Eliminar(int idCli)
        {
            bool respuesta;

            try
            {

                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.GetStringSql()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("eliminarCliente", conexion);
                    cmd.Parameters.AddWithValue("idCli", idCli);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;

            }

            return respuesta;
        }

    }
} 
