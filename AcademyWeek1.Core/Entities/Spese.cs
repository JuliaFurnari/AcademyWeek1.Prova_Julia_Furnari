using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWeek1.Core.Entities
{
    public class Spese
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public double Spesa { get; set; }
        public string Descrizione { get; set; }

        public bool? Approvata { get; set; }

        public double? Rimborso { get; set; }

        public Categoria CategoriaSpesa { get; set; }
        public Approvatori? ApprovatoriSpesa { get; set; }

        public int IdDipendente { get; set; }

    }
    public enum Categoria
    {
        Vitto =1,
        Alloggio = 2,
        Trasferta = 3,
        Altro = 4,
    }
    public enum Approvatori
    {
        Manager = 1,
        OperationManager = 2,
        CEO = 3,

    }
}
