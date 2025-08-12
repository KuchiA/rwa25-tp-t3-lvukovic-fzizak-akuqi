using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrticApp.Models
{
    public class Dolazak
    {
        public int DolazakId { get; set; }
        public int DijeteId { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan? VrijemeDolaska { get; set; }
        public TimeSpan? VrijemeOdlaska { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
}
