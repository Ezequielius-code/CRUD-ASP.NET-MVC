using CRUD_Web.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_Web.Datos
{
    public class ClienteDatos
    {
        //Read
        public List<ModelCliente> Listar()
        {
            var listaClientes = new List<ModelCliente>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();

                SqlCommand sqlCommand = new SqlCommand("Listar", conexion);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listaClientes.Add(new ModelCliente()
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Nombre = dataReader["nombre"].ToString(),
                            Direccion = dataReader["direccion"].ToString(),
                            Poblacion = dataReader["poblacion"].ToString(),
                            Telefono = dataReader["telefono"].ToString(),
                        });
                    }
                }
            }
            return listaClientes;
        }

        //Read by
        public ModelCliente GetCliente(int id)
        {
            var cliente = new ModelCliente();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();

                SqlCommand sqlCommand = new SqlCommand("GetCliente", conexion);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        cliente.Id = Convert.ToInt32(dataReader["id"]);
                        cliente.Nombre = dataReader["nombre"].ToString();
                        cliente.Direccion = dataReader["direccion"].ToString();
                        cliente.Poblacion = dataReader["poblacion"].ToString();
                        cliente.Telefono = dataReader["telefono"].ToString();
                    }
                }
            }
            return cliente;
        }

        //Create
        public bool Guardar (ModelCliente cliente)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand sqlCommand = new SqlCommand("Guardar", conexion);
                    sqlCommand.Parameters.AddWithValue("nombre", cliente.Nombre);
                    sqlCommand.Parameters.AddWithValue("direccion", cliente.Direccion);
                    sqlCommand.Parameters.AddWithValue("poblacion", cliente.Poblacion);
                    sqlCommand.Parameters.AddWithValue("telefono", cliente.Telefono);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
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
        public bool Editar(ModelCliente cliente)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand sqlCommand = new SqlCommand("Editar", conexion);
                    sqlCommand.Parameters.AddWithValue("id", cliente.Id);
                    sqlCommand.Parameters.AddWithValue("nombre", cliente.Nombre);
                    sqlCommand.Parameters.AddWithValue("direccion", cliente.Direccion);
                    sqlCommand.Parameters.AddWithValue("poblacion", cliente.Poblacion);
                    sqlCommand.Parameters.AddWithValue("telefono", cliente.Telefono);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
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

        //Delete
        public bool Eliminar(int id)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand sqlCommand = new SqlCommand("Eliminar", conexion);
                    sqlCommand.Parameters.AddWithValue("id", id);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
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
