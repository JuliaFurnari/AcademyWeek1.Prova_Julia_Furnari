using AcademyWeek1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWeek1.Core.Interfaces
{
    public interface IBusinessLayer
    {
        Dipendenti GetDipendenteByNome(string nome);
  
        void EseguiCalcoli();
      
        List<Spese> GetSpeseApprovateByDipendente(Dipendenti dipen);
    }
}
