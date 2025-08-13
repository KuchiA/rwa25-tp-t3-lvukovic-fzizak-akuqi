using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrticApp.Models
{
    public class Dijete
    {
        public int DijeteId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string EmailRoditelja { get; set; }
        public int GrupaId { get; set; }

        public string ImePrezime => $"{Ime} {Prezime}";
    }
}
