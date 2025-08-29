using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VrticApp.Models;

namespace VrticApp.Services
{
    public class AktivnostService
    {
        private readonly string _connectionString =
            "Data Source=31.147.206.65;Initial Catalog=RWA2514_DB;User ID=RWA2514_User;Password=.dhKxJs8";

        // Pročitaj sve aktivnosti
        public List<Aktivnost> DohvatiSve()
        {
            var lista = new List<Aktivnost>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"SELECT IdAktivnost, imeAktivnosti, grupa_id, datumAktivnosti, opisAktivnosti
                  FROM dbo.Aktivnost
                  ORDER BY datumAktivnosti DESC, IdAktivnost DESC;", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Aktivnost
                        {
                            IdAktivnost = reader.GetInt32(0),
                            ImeAktivnosti = reader.GetString(1),
                            GrupaId = reader.GetInt32(2),
                            DatumAktivnosti = reader.GetDateTime(3),
                            OpisAktivnosti = reader.IsDBNull(4) ? "" : reader.GetString(4)
                        });
                    }
                }
            }

            return lista;
        }

        // Dodaj novu aktivnost
        public void Dodaj(Aktivnost aktivnost)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"INSERT INTO dbo.Aktivnost (imeAktivnosti, grupa_id, datumAktivnosti, opisAktivnosti)
                  VALUES (@ime, @grupaId, @datum, @opis);", conn))
            {
                cmd.Parameters.AddWithValue("@ime", aktivnost.ImeAktivnosti?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@grupaId", aktivnost.GrupaId);
                cmd.Parameters.AddWithValue("@datum", aktivnost.DatumAktivnosti.Date);
                cmd.Parameters.AddWithValue("@opis", (object)(aktivnost.OpisAktivnosti ?? ""));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Ažuriraj postojeću aktivnost
        public void Azuriraj(Aktivnost aktivnost)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"UPDATE dbo.Aktivnost
                  SET imeAktivnosti = @ime,
                      grupa_id      = @grupaId,
                      datumAktivnosti = @datum,
                      opisAktivnosti  = @opis
                  WHERE IdAktivnost = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@ime", aktivnost.ImeAktivnosti?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@grupaId", aktivnost.GrupaId);
                cmd.Parameters.AddWithValue("@datum", aktivnost.DatumAktivnosti.Date);
                cmd.Parameters.AddWithValue("@opis", (object)(aktivnost.OpisAktivnosti ?? ""));
                cmd.Parameters.AddWithValue("@id", aktivnost.IdAktivnost);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Zbriši aktivnost
        public void Obrisi(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"DELETE FROM dbo.Aktivnost WHERE IdAktivnost = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
