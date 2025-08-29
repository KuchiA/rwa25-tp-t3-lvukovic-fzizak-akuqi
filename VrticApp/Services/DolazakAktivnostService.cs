using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VrticApp.Models;

namespace VrticApp.Services
{
    public class DolazakAktivnostService
    {
        private readonly string _connectionString =
            "Data Source=31.147.206.65;Initial Catalog=RWA2514_DB;User ID=RWA2514_User;Password=.dhKxJs8";

        // Dohvati sve zapise
        public List<DolazakAktivnost> DohvatiSve()
        {
            var lista = new List<DolazakAktivnost>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"SELECT Id, AktivnostId, DijeteId, Sudjelovao
                  FROM dbo.DolazakAktivnost
                  ORDER BY Id DESC;", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new DolazakAktivnost
                        {
                            Id = reader.GetInt32(0),
                            AktivnostId = reader.GetInt32(1),
                            DijeteId = reader.GetInt32(2),
                            Sudjelovao = reader.GetBoolean(3)
                        });
                    }
                }
            }

            return lista;
        }

        // Dohvati po aktivnosti
        public List<DolazakAktivnost> DohvatiPoAktivnosti(int aktivnostId)
        {
            var lista = new List<DolazakAktivnost>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"SELECT Id, AktivnostId, DijeteId, Sudjelovao
                  FROM dbo.DolazakAktivnost
                  WHERE AktivnostId = @aktivnostId
                  ORDER BY Id;", conn))
            {
                cmd.Parameters.AddWithValue("@aktivnostId", aktivnostId);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new DolazakAktivnost
                        {
                            Id = reader.GetInt32(0),
                            AktivnostId = reader.GetInt32(1),
                            DijeteId = reader.GetInt32(2),
                            Sudjelovao = reader.GetBoolean(3)
                        });
                    }
                }
            }

            return lista;
        }

        // Dodaj novi zapis
        public void Dodaj(DolazakAktivnost sudjelovanje)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"INSERT INTO dbo.DolazakAktivnost (AktivnostId, DijeteId, Sudjelovao)
                  VALUES (@aktivnostId, @dijeteId, @sudjelovao);", conn))
            {
                cmd.Parameters.AddWithValue("@aktivnostId", sudjelovanje.AktivnostId);
                cmd.Parameters.AddWithValue("@dijeteId", sudjelovanje.DijeteId);
                cmd.Parameters.AddWithValue("@sudjelovao", sudjelovanje.Sudjelovao);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Provjeri je li već postoji zapis za dijete na aktivnosti
        public bool PostojiSudjelovanje(int aktivnostId, int dijeteId)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"SELECT COUNT(*) FROM dbo.DolazakAktivnost
                  WHERE AktivnostId = @aktivnostId AND DijeteId = @dijeteId;", conn))
            {
                cmd.Parameters.AddWithValue("@aktivnostId", aktivnostId);
                cmd.Parameters.AddWithValue("@dijeteId", dijeteId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Obriši po Id-u
        public void Obrisi(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"DELETE FROM dbo.DolazakAktivnost WHERE Id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Obriši sve zapise za određenu aktivnost (npr. ako se briše cijela aktivnost)
        public void ObrisiPoAktivnosti(int aktivnostId)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"DELETE FROM dbo.DolazakAktivnost WHERE AktivnostId = @aktivnostId;", conn))
            {
                cmd.Parameters.AddWithValue("@aktivnostId", aktivnostId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}