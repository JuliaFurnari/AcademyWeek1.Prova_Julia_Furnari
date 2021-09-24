using AcademyWeek1.Core;
using AcademyWeek1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWeek1.AdoRepository
{
    public class DipendentiRepository : IDipendenti
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = AcademyI.EsercitazioneFinale;" +
                                         "Integrated Security = true";
        public Dipendenti GetByNome(string nome)
        {
           try
           {
               using (SqlConnection connection = new SqlConnection(connectionString))
               {
                        connection.Open();

                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "select * from dbo.Dipendenti where Nome = @nome";
                        command.Parameters.AddWithValue("@nome", nome);

                        SqlDataReader reader = command.ExecuteReader();
                       Dipendenti dipendente = new Dipendenti();

                       while (reader.Read())
                        {
                           
                            dipendente.Id = (int)reader["Id"];
                            dipendente.Nome =(string)reader["Nome"];                          
                        }

                        return dipendente;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            
        }
    }
}
