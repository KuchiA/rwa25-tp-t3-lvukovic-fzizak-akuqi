using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VrticApp.Models;

namespace VrticApp.Services
{
    public class DolazakService
    {
        private readonly string _connectionString = "Data Source=31.147.206.65;Initial Catalog=RWA2514_DB;User ID=RWA2514_User;Password=.dhKxJs8";

        public List<Grupa> GetGroups()
        {
            List<Grupa> grupe = new List<Grupa>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = "SELECT grupa_id, naziv, kapacitet FROM Grupa";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        grupe.Add(new Grupa
                        {
                            GrupaId = reader.GetInt32(0),
                            Naziv = reader.GetString(1),
                            Kapacitet = reader.GetInt32(2)
                        });
                    }
                }
            }

            return grupe;
        }

        public List<Dolazak> GetDolazak(int grupaId, DateTime datum)
        {
            List<Dolazak> dolasci = new List<Dolazak>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT d.dolazak_id, d.dijete_id, dj.ime, dj.prezime, d.datum, d.vrijeme_dolaska, d.vrijeme_odlaska
                    FROM Dolazak d
                    INNER JOIN Dijete dj ON d.dijete_id = dj.dijete_id
                    WHERE dj.grupa_id = @grupaId AND d.datum = @datum
                    ORDER BY dj.prezime, dj.ime";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@grupaId", grupaId);
                    cmd.Parameters.AddWithValue("@datum", datum);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dolasci.Add(new Dolazak
                            {
                                DolazakId = reader.GetInt32(0),
                                DijeteId = reader.GetInt32(1),
                                Ime = reader.GetString(2),
                                Prezime = reader.GetString(3),
                                Datum = reader.GetDateTime(4),
                                VrijemeDolaska = reader.IsDBNull(5) ? (TimeSpan?)null : reader.GetTimeSpan(5),
                                VrijemeOdlaska = reader.IsDBNull(6) ? (TimeSpan?)null : reader.GetTimeSpan(6)
                            });
                        }
                    }
                }
            }

            return dolasci;
        }

        public bool UpdateDolazak(List<Dolazak> dolasci)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                foreach (var dolazak in dolasci)
                {
                    string query = @"UPDATE Dolazak SET 
                                vrijeme_dolaska = @vrijemeDolaska, 
                                vrijeme_odlaska = @vrijemeOdlaska
                             WHERE dolazak_id = @dolazakId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@vrijemeDolaska", (object)dolazak.VrijemeDolaska ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@vrijemeOdlaska", (object)dolazak.VrijemeOdlaska ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@dolazakId", dolazak.DolazakId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            // Ako update nije uspio za neki zapis, možeš odmah vratiti false ili nastaviti dalje
                            return false;
                        }
                    }
                }
            }
            return true;
        }

    }
}
