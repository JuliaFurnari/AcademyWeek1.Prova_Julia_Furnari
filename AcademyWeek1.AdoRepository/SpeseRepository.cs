using AcademyWeek1.Core.Entities;
using AcademyWeek1.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWeek1.AdoRepository
{
    public class SpeseRepository:ISpese
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog = AcademyI.EsercitazioneFinale;" +
                                          "Integrated Security = true";

        public List<Spese> FetchByDipendendete(Dipendenti dipen)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from dbo.Spese where Approvata = 1 and Dipendente = @dipendente";
                    command.Parameters.AddWithValue("@dipendente", dipen.Id);
                    SqlDataReader reader = command.ExecuteReader();

                    List<Spese> spese = new List<Spese>();

                    while (reader.Read())
                    {
                        Spese spesa = new Spese();
                        spesa.Id = (int)reader["Id"];
                        spesa.Data = Convert.ToDateTime(reader["Data"]);
                        spesa.Spesa = (double)(reader["Spesa"]);
                        spesa.CategoriaSpesa = (Categoria)(reader["Categoria"]);
                        spesa.Descrizione = (string)(reader["Descrizione"]);
                        spesa.IdDipendente = (int)(reader["Dipendente"]);
                        spesa.Approvata = Convert.IsDBNull(reader["Approvata"]) ? null : (bool?)reader["Approvata"];
                        spesa.Rimborso = Convert.IsDBNull(reader["Rimborso"]) ? null : (double?)(reader["Rimborso"]);
                        spesa.ApprovatoriSpesa = Convert.IsDBNull(reader["Approvatore"]) ? null : (Approvatori)(reader["Approvatore"]);

                        spese.Add(spesa);
                    }

                    return spese;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Spese> GetItemsWithOutApprovata()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from dbo.Spese where Approvata is null";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Spese> spese = new List<Spese>();

                    while (reader.Read())
                    {
                        Spese spesa = new Spese();
                        spesa.Id = (int)reader["Id"];
                        spesa.Data = Convert.ToDateTime(reader["Data"]); 
                        spesa.Spesa = (double)(reader["Spesa"]);
                        spesa.CategoriaSpesa = (Categoria)(reader["Categoria"]);
                        spesa.Descrizione = (string)(reader["Descrizione"]);
                        spesa.IdDipendente = (int)(reader["Dipendente"]);         
                        spesa.Approvata = Convert.IsDBNull(reader["Approvata"]) ? null : (bool?)reader["Approvata"];
                        spesa.Rimborso = Convert.IsDBNull(reader["Rimborso"]) ? null : (double?)(reader["Rimborso"]);
                        spesa.ApprovatoriSpesa = Convert.IsDBNull(reader["Approvatore"]) ? null : (Approvatori)(reader["Approvatore"]);

                        spese.Add(spesa);
                    }

                    return spese;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
         

        public void Update(Spese spesa)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "update Spese set Data = @data, Spesa = @spesa," +
                                          " Categoria = @categoria, Descrizione = @descrizione," +
                                          "Dipendente = @dipendente, Approvata = @approvata, Rimborso = @rimborso," +
                                          "Approvatore = @approvatore where Id = @id";
                    command.Parameters.AddWithValue("@id", spesa.Id);
                    command.Parameters.AddWithValue("@data", spesa.Data);
                    command.Parameters.AddWithValue("@spesa", spesa.Spesa);
                    command.Parameters.AddWithValue("@categoria", (int)spesa.CategoriaSpesa);
                    command.Parameters.AddWithValue("@descrizione", spesa.Descrizione);
                    command.Parameters.AddWithValue("@dipendente", spesa.IdDipendente);
                    command.Parameters.AddWithValue("@approvata", spesa.Approvata);
                    command.Parameters.AddWithValue("@rimborso", (spesa.Rimborso == null) ? DBNull.Value : spesa.Rimborso );
                    command.Parameters.AddWithValue("@approvatore", (spesa.ApprovatoriSpesa==null) ? DBNull.Value : spesa.ApprovatoriSpesa);
                



                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
