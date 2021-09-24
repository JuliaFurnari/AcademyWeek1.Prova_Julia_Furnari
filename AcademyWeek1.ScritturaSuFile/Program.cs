using AcademyWeek1.AdoRepository;
using AcademyWeek1.Core;
using static AcademyWeek1.Core.Evento;
using AcademyWeek1.Core.Entities;
using AcademyWeek1.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace AcademyWeek1.ScritturaSuFile
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new DipendentiRepository(), new SpeseRepository());
        static void Main(string[] args)
        {


            Console.WriteLine("Inserisci il tuo nome");

            string nome;
            nome = Console.ReadLine();
            try
            {

                Dipendenti dipen = new Dipendenti();
                dipen = bl.GetDipendenteByNome(nome);

                //Creazione file con le spese approvate
                List<Spese> spese = new List<Spese>();
                spese = bl.GetSpeseApprovateByDipendente(dipen);

                Evento evento = new Evento();
                evento.MandaLaNotifica += ScriviSuFile;

                if (spese.Count >0 )
                {
                    
                    foreach (Spese spesa in spese)
                    {
                        evento.AutenticazioneDipendente(spesa);
                    }
                }


            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
        }

        private static void ScriviSuFile(Evento evento, Spese spesa)
        {
            string path = @"C:\Users\julia.Furnari\Desktop\SpeseApprovate.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                   
                    sw.WriteLine($"{ spesa.Data} - { spesa.CategoriaSpesa}"
                        + $" - {spesa.Spesa} - {spesa.Approvata} - {spesa.Rimborso}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

