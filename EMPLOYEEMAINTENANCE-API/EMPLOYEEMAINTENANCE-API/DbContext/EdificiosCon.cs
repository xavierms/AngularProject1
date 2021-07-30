using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public class EdificiosCon: IEdificiosCon

    {
        IConfiguration _configuration;
        public EdificiosCon(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //string ConnectionString = "Server=.;Initial Catalog=EMPLOYEEMANAG;persist security info=True;Integrated Security=SSPI;";

        //Get list Edificios
        public IEnumerable<Edificios> Lists()
        {
            List<Edificios> listEdificios = new List<Edificios>();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {
                SqlCommand cmd = new SqlCommand("ListadoEdificios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Edificios edif = new Edificios
                    {
                        EdificiosId = Convert.ToInt32(dr["ID"]),
                        EdificioNum = dr["EdificioNum"].ToString(),
                        EdificioDireccion = dr["EdificioDireccion"].ToString(),
                        TipoEdif = dr["TipoEdif"].ToString(),
                        NivelCal = dr["NivelCal"].ToString(),
                        Categor = dr["Categor"].ToString()
                    };
                    listEdificios.Add(edif);
                }
                con.Close();
            }
            return listEdificios;
        }

        //Read for ID 
        public Edificios BuscarPorID(int id)
        {
            Edificios edif = new Edificios();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {
                SqlCommand cmd = new("edificioPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    edif.EdificiosId = Convert.ToInt32(dr["ID"]);
                    edif.EdificioNum = dr["EdificioNum"].ToString();
                    edif.EdificioDireccion = dr["EdificioDireccion"].ToString();
                    edif.TipoEdif = dr["TipoEdif"].ToString();
                    edif.NivelCal = dr["NivelCal"].ToString();
                    edif.Categor = dr["Categor"].ToString();
                }
                con.Close();

            }
            return edif;
        }
        //Create Edificios
        public void Añadir(Edificios model)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

            {
                SqlCommand cmd = new SqlCommand("insertarEdificio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EdificioNum", model.EdificioNum);
                cmd.Parameters.AddWithValue("@EdificioDireccion", model.EdificioDireccion);
                cmd.Parameters.AddWithValue("@TipoEdif", model.TipoEdif);
                cmd.Parameters.AddWithValue("@NivelCal", model.NivelCal);
                cmd.Parameters.AddWithValue("@Categor", model.Categor);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Remove Edificios
        public void Borrar(int? id)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {
                SqlCommand cmd = new SqlCommand("borrarEdificio", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Update Edificios
        public void Actualizar(Edificios model, int id)
        {
            model.EdificiosId = id;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

            {
                SqlCommand cmd = new SqlCommand("actualizarEdificio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", model.EdificiosId);
                cmd.Parameters.AddWithValue("@EdificioNum", model.EdificioNum);
                cmd.Parameters.AddWithValue("@EdificioDireccion", model.EdificioDireccion);
                cmd.Parameters.AddWithValue("@TipoEdif", model.TipoEdif);
                cmd.Parameters.AddWithValue("@NivelCal", model.NivelCal);
                cmd.Parameters.AddWithValue("@Categor", model.Categor);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}
