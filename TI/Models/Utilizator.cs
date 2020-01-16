using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI.Models
{
    [Table("utilizator")]
    public class Utilizator
    {
        [Key]
        public double NrCrt { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Functie { get; set; }
        public double SalarBaza { get; set; }
        public double Spor { get; set; }
        public double PremiiBrute { get; set; }
        public double TotalBrut { get; set; }
        public double BrutImpozitabil { get; set; }
        public double Virat { get; set; }
        public double Impozit { get; set; }
        public double CAS { get; set; }
        public double CASS { get; set; }
        public double Retineri { get; set; }
    }
}