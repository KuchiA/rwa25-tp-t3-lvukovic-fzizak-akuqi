using System;
using System.Data.SqlClient;
using VrticApp.Models;
using VrticApp.Helpers;

namespace VrticApp.Services
{
    public class KorisnikService
    {
        private readonly string _connectionString = "Data Source=31.147.206.65;Initial Catalog=RWA2514_DB;User ID=RWA2514_User;Password=.dhKxJs8";

        public Korisnik PrijaviKorisnika(string korisnickoIme, string lozinka)
        {
            Korisnik korisnik = null;

            string lozinkaHash = SecurityHelper.IzracunajSHA256(lozinka);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT korisnik_id, korisnicko_ime, lozinka_hash, uloga 
                                 FROM Korisnik 
                                 WHERE korisnicko_ime = @ime AND lozinka_hash = @lozinka";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ime", korisnickoIme);
                    cmd.Parameters.AddWithValue("@lozinka", lozinkaHash);


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
