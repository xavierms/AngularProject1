using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public class TrabajadorCon : ITrabajadorCon
    {
        IConfiguration _configuration;
        public TrabajadorCon(IConfiguration configuration)
        {
            _configuration = configuration;
        }

      //  string ConnectionString = "Server=.;Initial Catalog=EMPLOYEEMANAG;persist security info=True;Integrated Security=SSPI;";

        public IEnumerable<Trabajador> Lists()
        {
            List<Trabajador> listTrabajadores = new List<Trabajador>();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {
                SqlCommand cmd = new SqlCommand("ListadoTrabajador", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Trabajador trb = new Trabajador
                    {
                        Trabajadorid = Convert.ToInt32(dr["ID"]),
                        TrabajadorNum = dr["TrabajadorNum"].ToString(),
                        TrabajadorNomb = dr["TrabajadorNomb"].ToString(),
                        TrabajadorTarif = dr["TrabajadorTarif"].ToString(),
                        Oficio = dr["Oficio"].ToString(),
                        TrabajadorSuper = dr["TrabajadorSuper"].ToString()
                    };

                    listTrabajadores.Add(trb);

                }
                con.Close();

            }
            return listTrabajadores;

        }

        public Trabajador BuscarPorID(int id)
        {
            Trabajador trb = new Trabajador();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {
                SqlCommand cmd = new SqlCommand("trabajadorPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    trb.Trabajadorid = Convert.ToInt32(dr["ID"]);
                    trb.TrabajadorNum = dr["TrabajadorNum"].ToString();
                    trb.TrabajadorNomb = dr["TrabajadorNomb"].ToString();
                    trb.TrabajadorTarif = dr["TrabajadorTarif"].ToString();
                    trb.Oficio = dr["Oficio"].ToString();
                    trb.TrabajadorSuper = dr["TrabajadorSuper"].ToString();

                }
                con.Close();

            }
            return trb;

        }

        public void Añadir(Trabajador model)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

            {
                SqlCommand cmd = new SqlCommand("insertarTrabajador", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TrabajadorNomb", model.TrabajadorNomb);
                cmd.Parameters.AddWithValue("@TrabajadorNum", model.TrabajadorNum);
                cmd.Parameters.AddWithValue("@TrabajadorSuper", model.TrabajadorSuper);
                cmd.Parameters.AddWithValue("@TrabajadorTarif", model.TrabajadorTarif);
                cmd.Parameters.AddWithValue("@Oficio", model.Oficio);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void Borrar(int? id)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

            {
                SqlCommand cmd = new SqlCommand("borrarTrabajador", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }


        public void Actualizar(Trabajador model, int id)
        {
            model.Trabajadorid = id;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

            {
                SqlCommand cmd = new SqlCommand("actualizarTrabajador", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", model.Trabajadorid);
                cmd.Parameters.AddWithValue("@TrabajadorNomb", model.TrabajadorNomb);
                cmd.Parameters.AddWithValue("@TrabajadorNum", model.TrabajadorNum);
                cmd.Parameters.AddWithValue("@TrabajadorSuper", model.TrabajadorSuper);
                cmd.Parameters.AddWithValue("@TrabajadorTarif", model.TrabajadorTarif);
                cmd.Parameters.AddWithValue("@Oficio", model.Oficio);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

    }
}