using AcademyWeek1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWeek1.Core
{
    public interface IDipendenti
    {
        Dipendenti GetByNome(string nome);
    }
}
