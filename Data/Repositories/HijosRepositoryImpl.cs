using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data.Repositories
{
    public class HijosRepositoryImpl : IHijosRepository
    {
        private readonly SqlConnection con = new SqlConnection("Server=GONZALO-PC\\SQLEXPRESS;Database=GonzaloVeramendi;ConnectRetryCount=0;User ID=sa; Password=12345678");

        public IEnumerable<Hijo> GetHijos()
        {
            List<Hijo> lstHijos;
            try
            {
                lstHijos = new List<Hijo>();
                SqlCommand cmd = new SqlCommand("sp_hijos_get", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Hijo hijo = new Hijo();
                    hijo.IdDerHab = Convert.ToInt32(rdr["IdDerHab"]);
                    hijo.ApPaterno = rdr["ApPaterno"].ToString();
                    hijo.ApMaterno = rdr["ApMaterno"].ToString();
                    hijo.Nombre1 = rdr["Nombre1"].ToString();
                    hijo.Nombre2 = rdr["Nombre2"].ToString();
                    hijo.NombreCompleto = rdr["NombreCompleto"].ToString();
                    hijo.FchNac = Convert.ToDateTime(rdr["FchNac"]);
                    hijo.Padre = new Personal() { IdPersonal = Convert.ToInt32(rdr["IdPersonal"]) };
                    lstHijos.Add(hijo);
                }
                con.Close();
                return lstHijos;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw ex;
            }
        }

        public Hijo GetHijoById(int id)
        {
            Hijo hijo = null;
            try
            {
                
                SqlCommand cmd = new SqlCommand("sp_hijos_getById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDerHab", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    hijo = new Hijo();
                    hijo.IdDerHab = Convert.ToInt32(rdr["IdDerHab"]);
                    hijo.ApPaterno = rdr["ApPaterno"].ToString();
                    hijo.ApMaterno = rdr["ApMaterno"].ToString();
                    hijo.Nombre1 = rdr["Nombre1"].ToString();
                    hijo.Nombre2 = rdr["Nombre2"].ToString();
                    hijo.NombreCompleto = rdr["NombreCompleto"].ToString();
                    hijo.FchNac = Convert.ToDateTime(rdr["FchNac"]);
                    hijo.Padre = new Personal() { IdPersonal = Convert.ToInt32(rdr["IdPersonal"]) };
                }
                con.Close();
                return hijo;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw ex;
            }
        }

        public IEnumerable<Hijo> GetHijoByIdPersonal(int id)
        {
            List<Hijo> lstHijos;
            lstHijos = new List<Hijo>();
            try
            {

                SqlCommand cmd = new SqlCommand("sp_hijos_getByIdPersonal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersonal", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Hijo hijo = new Hijo();
                    hijo = new Hijo();
                    hijo.IdDerHab = Convert.ToInt32(rdr["IdDerHab"]);
                    hijo.ApPaterno = rdr["ApPaterno"].ToString();
                    hijo.ApMaterno = rdr["ApMaterno"].ToString();
                    hijo.Nombre1 = rdr["Nombre1"].ToString();
                    hijo.Nombre2 = rdr["Nombre2"].ToString();
                    hijo.NombreCompleto = rdr["NombreCompleto"].ToString();
                    hijo.FchNac = Convert.ToDateTime(rdr["FchNac"]);
                    hijo.Padre = new Personal() { IdPersonal = Convert.ToInt32(rdr["IdPersonal"]) };
                    lstHijos.Add(hijo);
                }
                con.Close();
                return lstHijos;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw ex;
            }
        }

        public bool AddHijo(Hijo hijo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_hijos_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApPaterno", hijo.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", hijo.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", hijo.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", hijo.Nombre2);
                cmd.Parameters.AddWithValue("@FchNac", hijo.FchNac);
                cmd.Parameters.AddWithValue("@IdPersonal", hijo.Padre.IdPersonal);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw ex;
            }
        }

        public bool DeleteHijo(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_hijos_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDerHab", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw ex;
            }
        }

        public bool UpdateHijo(int id, Hijo hijo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_hijos_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDerHab", hijo.IdDerHab);
                cmd.Parameters.AddWithValue("@ApPaterno", hijo.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", hijo.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", hijo.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", hijo.Nombre2);
                cmd.Parameters.AddWithValue("@FchNac", hijo.FchNac);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw ex;
            }
        }
    }
}
