using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyWeek1.Core.Interfaces;

namespace AcademyWeek1.Core.Entities
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IDipendenti dipendentiRepo;
        private readonly ISpese speseRepo;


        public BusinessLayer(IDipendenti dipendentiRepository, ISpese speseRepository)
        {
             dipendentiRepo = dipendentiRepository;
              speseRepo = speseRepository ;
        }

        public void EseguiCalcoli()
        {

            List<Spese> spese = new List<Spese>();
            try
            {
                
                spese = speseRepo.GetItemsWithOutApprovata();

                if (spese.Count() > 0)
                {
                    foreach (var spesa in spese)
                    {
                        if (spesa.Spesa <= 400)
                        {
                            spesa.ApprovatoriSpesa = Approvatori.Manager;
                            spesa.Approvata = true;
                            CalcolaRimborso(spesa);

                        }
                        else if (spesa.Spesa > 400 && spesa.Spesa <= 1000)
                        {
                            spesa.ApprovatoriSpesa = Approvatori.OperationManager;
                            spesa.Approvata = true;
                            CalcolaRimborso(spesa);
                        }
                        else if (spesa.Spesa > 1000 && spesa.Spesa < 2500)
                        {
                            spesa.ApprovatoriSpesa = Approvatori.CEO;
                            spesa.Approvata = true;
                            CalcolaRimborso(spesa);
                        }
                        else
                        {
                            spesa.Approvata = false;
                            spesa.Rimborso = null;
                            spesa.ApprovatoriSpesa = null;
                        }
                        //Salvare  sul db
                        speseRepo.Update(spesa);



                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dipendenti GetDipendenteByNome(string nome)
        {
            try
            {
                Dipendenti dipend = new Dipendenti();
                dipend = dipendentiRepo.GetByNome(nome);
                return dipend;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public List<Spese> GetSpeseApprovateByDipendente(Dipendenti dipen)
        {
            try
            {
                List<Spese> spese = new List<Spese>();
                spese = speseRepo.FetchByDipendendete(dipen);
                return spese;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

     
   

        private void CalcolaRimborso(Spese spesa)
        {
            if (spesa.CategoriaSpesa == Categoria.Vitto) spesa.Rimborso = (spesa.Spesa * 70) / 100;
            if (spesa.CategoriaSpesa == Categoria.Alloggio) spesa.Rimborso = spesa.Spesa;
            if (spesa.CategoriaSpesa == Categoria.Trasferta) spesa.Rimborso = (spesa.Spesa / 2) + 50;
            if (spesa.CategoriaSpesa == Categoria.Altro) spesa.Rimborso = (spesa.Spesa * 10) / 100;
        }
    }
}
