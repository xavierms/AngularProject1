using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public class AsignacionesCon: IAsignacionesCon
    {
        IConfiguration _configuration;
        public AsignacionesCon(IConfiguration  configuration)
        {
            _configuration = configuration;
        }
        //string ConnectionString = "Server=DTIC-16\\SQLSERVERX;Initial Catalog=EMPLOYEEMANAG;persist security info=True;Integrated Security=SSPI;";

        //Get list Asignaciones
        public IEnumerable<Asignaciones> Lists()
            {
                List<Asignaciones> listAsignaciones = new List<Asignaciones>();

                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
                {
                    SqlCommand cmd = new SqlCommand("ListadoAsignaciones", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Asignaciones asig = new Asignaciones
                        {
                            Asignacionid = Convert.ToInt32(dr["ID"]),
                            AsigNum = dr["AsigNum"].ToString(),
                            AsigFechIni = dr["AsigFechIni"].ToString(),
                            AsigNumDias = dr["AsigNumDias"].ToString(), 
                            EdificioNum_fk = Convert.ToInt32(dr["EdificioNum_fk"]),
                            TrabajadorNum_fk = Convert.ToInt32(dr["TrabajadorNum_fk"]),
                        };
                        listAsignaciones.Add(asig);
                    }
                    con.Close();
                }
                return listAsignaciones;
            }

            //Read for ID 
            public Asignaciones BuscarPorID(int id)
            {

                Asignaciones asg = new Asignaciones();
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
                {
                    SqlCommand cmd = new("asignacionPorId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        asg.Asignacionid = Convert.ToInt32(dr["ID"]);
                        asg.AsigNum = dr["AsigNum"].ToString();
                        asg.AsigFechIni = dr["AsigFechIni"].ToString();
                        asg.AsigNumDias = dr["AsigNumDias"].ToString();
                        asg.EdificioNum_fk = Convert.ToInt32(dr["EdificioNum_fk"]);
                        asg.TrabajadorNum_fk = Convert.ToInt32(dr["TrabajadorNum_fk"]);

                    };
                    con.Close();
                }
                return asg;
            }
            //Create Asignaciones
            public void Añadir(Asignaciones model)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

                {
                    SqlCommand cmd = new SqlCommand("insertarAsignacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", model.Asignacionid);
                    cmd.Parameters.AddWithValue("@AsigNum", model.AsigNum);
                    cmd.Parameters.AddWithValue("@AsigFechIni", DateTime.Parse( model.AsigFechIni)); 
                    cmd.Parameters.AddWithValue("@AsigNumDias", model.AsigNumDias);
                    cmd.Parameters.AddWithValue("@EdificioNum_fk", model.EdificioNum_fk);
                    cmd.Parameters.AddWithValue("@TrabajadorNum_fk", model.TrabajadorNum_fk);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            //Remove Asignaciones
            public void Borrar(int? id)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
                {
                    SqlCommand cmd = new SqlCommand("borrarAsignacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            //Update Asignaciones
            public void Actualizar(Asignaciones model, int id)
            {
                model.Asignacionid = id;
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

                {
                    SqlCommand cmd = new SqlCommand("actualizarAsignacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@ID", model.Asignacionid);
                    cmd.Parameters.AddWithValue("@AsigNum", model.AsigNum);
                    cmd.Parameters.AddWithValue("@AsigFechIni", DateTime.Parse(model.AsigFechIni));
                    cmd.Parameters.AddWithValue("@AsigNumDias", model.AsigNumDias);
                    cmd.Parameters.AddWithValue("@EdificioNum_fk", model.EdificioNum_fk);
                    cmd.Parameters.AddWithValue("@TrabajadorNum_fk", model.TrabajadorNum_fk);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
        }

    }

