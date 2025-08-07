using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using VrticApp.Models;
using VrticApp.Helpers;

namespace VrticApp.Services
{
    public class KorisnikService
    {
        private readonly string _connectionString = "Data Source=localhost;Initial Catalog=VrticDB;Integrated Security=True";

        public Korisnik PrijaviKorisnika(string korisnickoIme, string lozinka)
        {
            Korisnik korisnik = null;

            string hashiranaLozinka = SecurityHelper.IzracunajSHA256(lozinka);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT korisnik_id, korisnicko_ime, lozinka_hash, uloga FROM Korisnik WHERE korisnicko_ime = @ime AND lozinka_hash = @lozinka";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ime", korisnickoIme);
                    cmd.Parameters.AddWithValue("@lozinka", hashiranaLozinka);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            korisnik = new Korisnik
                            {
                                KorisnikId = reader.GetInt32(0),
                                KorisnickoIme = reader.GetString(1),
                                LozinkaHash = reader.GetString(2),
                                Uloga = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return korisnik;
        }
    }
}

