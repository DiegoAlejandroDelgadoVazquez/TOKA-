using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST_DEV_API_DADV_26032022.Models;

namespace TEST_DEV_API_DADV_26032022.DataAccess
{
    public class dbPersonaFisica
    {
        public List<PersonaFisica> Get()
        {
          
            List<PersonaFisica> list = new List<PersonaFisica>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConnectionObject.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "sp_ObtenerPersonaFisica";
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    PersonaFisica persona = new PersonaFisica();
                    persona.IdPersonaFisica = int.Parse(dr["IdPersonaFisica"].ToString());
                    persona.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString());
                    persona.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"].ToString());
                    persona.Nombre = dr["Nombre"].ToString();
                    persona.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                    persona.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                    persona.RFC = dr["RFC"].ToString();
                    persona.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString());
                    persona.UsuarioAgrega = int.Parse(dr["UsuarioAgrega"].ToString());
                    persona.Activo = bool.Parse(dr["Activo"].ToString());
                    list.Add(persona);
                }

            }
            catch (Exception E)
            {

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return list;
        }

        public Boolean Create(PersonaFisica personafisica)
        {
            var response = false;
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConnectionObject.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "sp_AgregarPersonaFisica";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Nombre", personafisica.Nombre));
                cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", personafisica.ApellidoPaterno));
                cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", personafisica.ApellidoMaterno));
                cmd.Parameters.Add(new SqlParameter("@RFC", personafisica.RFC));
                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", personafisica.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@UsuarioAgrega", personafisica.UsuarioAgrega));

                cmd.ExecuteNonQuery();
                response = true;

            }
            catch (Exception e)
            {

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return response;

        }

        public PersonaFisica GetById(int Id)
        {
            PersonaFisica persona = new PersonaFisica();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConnectionObject.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "sp_ObtenerPersonaFisicaPorId";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdPersonaFisica", Id));

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    persona.IdPersonaFisica = int.Parse(dr["IdPersonaFisica"].ToString());
                    persona.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString());
                    persona.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"].ToString());
                    persona.Nombre = dr["Nombre"].ToString();
                    persona.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                    persona.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                    persona.RFC = dr["RFC"].ToString();
                    persona.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString());
                    persona.UsuarioAgrega = int.Parse(dr["UsuarioAgrega"].ToString());
                    persona.Activo = bool.Parse(dr["Activo"].ToString());

                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return persona;
        }

        public bool Edit(PersonaFisica personafisica)
        {
            var response = false;
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConnectionObject.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "sp_ActualizarPersonaFisica";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdPersonaFisica", personafisica.IdPersonaFisica));
                cmd.Parameters.Add(new SqlParameter("@Nombre", personafisica.Nombre));
                cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", personafisica.ApellidoPaterno));
                cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", personafisica.ApellidoMaterno));
                cmd.Parameters.Add(new SqlParameter("@RFC", personafisica.RFC));
                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", personafisica.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@UsuarioAgrega", personafisica.UsuarioAgrega));
                cmd.Parameters.Add(new SqlParameter("@FechaActualizacion", DateTime.Now));
                cmd.ExecuteNonQuery();
                response = true;
            }
            catch (Exception E)
            {

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return response;
        }


        public bool Delete(int Id)
        {
            var response = false;
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConnectionObject.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "sp_EliminarPersonaFisica";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdPersonaFisica", Id));
                cmd.ExecuteNonQuery();
                response = true;

            }
            catch (Exception E)
            {

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return response;
        }
    }
}
