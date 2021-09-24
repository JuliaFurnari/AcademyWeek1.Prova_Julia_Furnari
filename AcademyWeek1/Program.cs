using AcademyWeek1.AdoRepository;
using AcademyWeek1.Core.Entities;
using AcademyWeek1.Core.Interfaces;
using System;

namespace AcademyWeek1
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new DipendentiRepository(), new SpeseRepository());
        static void Main(string[] args)
        {
            //Esegui calcoli

            try
            {

                bl.EseguiCalcoli();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

 
    }
}
