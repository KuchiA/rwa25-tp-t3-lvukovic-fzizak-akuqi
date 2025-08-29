using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrticApp.Models
{
    public class Aktivnost
    {
        public int IdAktivnost { get; set; }
        public string ImeAktivnosti { get; set; }
        public int GrupaId { get; set; }
        public DateTime DatumAktivnosti { get; set; }
        public string OpisAktivnosti { get; set; }

        // Za prikaz imena gurpe
        public Grupa Grupa { get; set; }
    }
}
