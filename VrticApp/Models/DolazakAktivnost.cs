using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrticApp.Models
{
    public class DolazakAktivnost
    {
        public int Id { get; set; }

        public int AktivnostId { get; set; }
        public int DijeteId { get; set; }

        // Sudjelovao = true ako je bio prisutan (default), false ako nije
        public bool Sudjelovao { get; set; } = true;

        // Navigacijske reference (opcionalno, za lakši prikaz/povezivanje)
        public Aktivnost Aktivnost { get; set; }
        public Dijete Dijete { get; set; }
    }
}
