using AcademyWeek1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWeek1.Core
{
    public class Evento
    {
        public delegate void ScriviSuFile(Evento evento, Spese spesa);

        public event ScriviSuFile MandaLaNotifica;

        public void AutenticazioneDipendente(Spese spesa)
        {
            if (MandaLaNotifica != null)
            {
                MandaLaNotifica(this, spesa);
            }
        }
    }
}
