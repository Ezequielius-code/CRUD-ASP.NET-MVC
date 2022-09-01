using CrudWebNetCore.Models;
using System.Data.SqlClient;
using System.Data;

namespace CrudWebNetCore.Datos
{
    public class ClienteDatos
    {
        //Read
        public List<ModelCliente> Listar()
        {
            var oLista = new List<ModelCliente>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ModelCliente()
                        {
                            IdContacto = Convert.ToInt32(dr["id"]),
                            nombre = dr["nombre"].ToString(),
                            direccion = dr["direccion"].ToString(),
                            poblacion = dr["poblacion"].ToString(),
                            telefono = dr["telefono"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        //Read by
        public ModelCliente Obtener(int id)
        {
            var oCliente = new ModelCliente();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("GetCliente", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCliente.IdContacto = Convert.ToInt32(dr["id"]);
                        oCliente.nombre = dr["nombre"].ToString();
                        oCliente.direccion = dr["direccion"].ToString();
                        oCliente.poblacion = dr["poblacion"].ToString();
                        oCliente.telefono = dr["telefono"].ToString();
                    }
                }
            }
            return oCliente;
        }

        //Create
        public bool Guardar(ModelCliente oCliente)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using(var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", conexion);
                    cmd.Parameters.AddWithValue("nombre", oCliente.nombre);
                    cmd.Parameters.AddWithValue("direccion", oCliente.direccion);
                    cmd.Parameters.AddWithValue("poblacion", oCliente.poblacion);
                    cmd.Parameters.AddWithValue("telefono", oCliente.telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        //Update
        public bool Editar(ModelCliente oCliente)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using(var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Editar", conexion);
                    cmd.Parameters.AddWithValue("id", oCliente.IdContacto);
                    cmd.Parameters.AddWithValue("nombre", oCliente.nombre);
                    cmd.Parameters.AddWithValue("direccion", oCliente.direccion);
                    cmd.Parameters.AddWithValue("poblacion", oCliente.poblacion);
                    cmd.Parameters.AddWithValue("telefono", oCliente.telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta=true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        //Delete
        public bool Eliminar(int id)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using(var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", conexion);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
