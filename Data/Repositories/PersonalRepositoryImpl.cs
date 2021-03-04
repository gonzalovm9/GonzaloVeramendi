using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data.Repositories
{
    public class PersonalRepositoryImpl : IPersonalRepository
    {
        private readonly SqlConnection con = new SqlConnection("Server=GONZALO-PC\\SQLEXPRESS;Database=GonzaloVeramendi;ConnectRetryCount=0;User ID=sa; Password=12345678");

        public IEnumerable<Personal> GetPersonal()
        {
            List<Personal> lstPersonal;
            try
            {
                lstPersonal = new List<Personal>();
                SqlCommand cmd = new SqlCommand("sp_personal_get", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Personal personal = new Personal();
                    personal.IdPersonal = Convert.ToInt32(rdr["IdPersonal"]);
                    personal.ApPaterno = rdr["ApPaterno"].ToString();
                    personal.ApMaterno = rdr["ApMaterno"].ToString();
                    personal.Nombre1 = rdr["Nombre1"].ToString();
                    personal.Nombre2 = rdr["Nombre2"].ToString();
                    personal.NombreCompleto = rdr["NombreCompleto"].ToString();
                    personal.FchNac = Convert.ToDateTime(rdr["FchNac"]);
                    personal.FchIngreso = Convert.ToDateTime(rdr["FchIngreso"]);
                    lstPersonal.Add(personal);
                }
                con.Close();
                return lstPersonal;
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

        public Personal GetPersonalById(int id)
        {
            Personal personal = null;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_personal_getById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersonal", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    personal = new Personal();
                    personal.IdPersonal = Convert.ToInt32(rdr["IdPersonal"]);
                    personal.ApPaterno = rdr["ApPaterno"].ToString();
                    personal.ApMaterno = rdr["ApMaterno"].ToString();
                    personal.Nombre1 = rdr["Nombre1"].ToString();
                    personal.Nombre2 = rdr["Nombre2"].ToString();
                    personal.NombreCompleto = rdr["NombreCompleto"].ToString();
                    personal.FchNac = Convert.ToDateTime(rdr["FchNac"]);
                    personal.FchIngreso = Convert.ToDateTime(rdr["FchIngreso"]);
                }
                con.Close();
                return personal;
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

        public bool AddPersonal(Personal personal)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_personal_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApPaterno", personal.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", personal.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", personal.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", personal.Nombre2);
                cmd.Parameters.AddWithValue("@FchNac", personal.FchNac);
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

        public bool DeletePersonal(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_personal_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersonal", id);
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

        public bool UpdatePersonal(int id, Personal personal)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_personal_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersonal", personal.IdPersonal);
                cmd.Parameters.AddWithValue("@ApPaterno", personal.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", personal.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", personal.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", personal.Nombre2);
                cmd.Parameters.AddWithValue("@FchNac", personal.FchNac);
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
