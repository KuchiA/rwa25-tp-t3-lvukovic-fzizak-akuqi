using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace VrticApp.Services
{
    public class StatistikaService
    {
        private readonly string _connectionString = "Data Source=31.147.206.65;Initial Catalog=RWA2514_DB;User ID=RWA2514_User;Password=.dhKxJs8";

        public DataTable UcitajGrupe()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT grupa_id, naziv FROM Grupa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }

        // Metoda DohvatiDolazke je ispravljena
        // Dodan je JOIN na Dijete tablicu, te se provjerava grupa_id direktno iz te tablice
        public DataTable DohvatiDolazke(int grupaId, DateTime startDate)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT d.dolazak_id, d.dijete_id, d.datum
                    FROM Dolazak d
                    INNER JOIN Dijete dj ON d.dijete_id = dj.dijete_id
                    WHERE dj.grupa_id = @grupaId
                    AND d.datum >= @startDate
                    AND d.vrijeme_dolaska IS NOT NULL -- Filtriranje samo zabilježenih dolazaka
                    ORDER BY d.datum ASC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@grupaId", grupaId);
                    cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Metoda za grupiranje dolazaka ostaje ista, jer je ispravna
        public List<(DateTime Datum, int BrojDolazaka)> GrupirajDolazkePoDatumu(DataTable dolasci)
        {
            return dolasci.AsEnumerable()
                           .GroupBy(r => Convert.ToDateTime(r["datum"]).Date)
                           .Select(g => (g.Key, g.Count()))
                           .OrderBy(x => x.Key)
                           .ToList();
        }
    }
}
