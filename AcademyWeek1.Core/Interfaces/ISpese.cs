using AcademyWeek1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWeek1.Core.Interfaces
{
    public interface ISpese 
    {

      
        List<Spese> GetItemsWithOutApprovata();
        void Update(Spese spesa);
        List<Spese> FetchByDipendendete(Dipendenti dipen);
    }
}
