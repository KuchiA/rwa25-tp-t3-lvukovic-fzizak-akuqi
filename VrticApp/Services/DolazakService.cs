using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using VrticApp.Models;

namespace VrticApp.Services
{
    public class DolazakService
    {
        private readonly string _connectionString = "Data Source=31.147.206.65;Initial Catalog=RWA2514_DB;User ID=RWA2514_User;Password=.dhKxJs8";

        public List<Grupa> GetGroups()
        {
            List<Grupa> grupe = new List<Grupa>();
            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri dohvatu grupa iz baze: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Grupa>();
            }
            return grupe;
        }

        public bool ProvjeriPostojeciDolazak(int dijeteId, DateTime datum)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Dolazak WHERE dijete_id = @dijeteId AND datum = @datum";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dijeteId", dijeteId);
                        cmd.Parameters.AddWithValue("@datum", datum.Date);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri provjeri dolaska: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        public int GetNextDolazakId()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ISNULL(MAX(dolazak_id), 0) FROM Dolazak";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int maxId = (int)cmd.ExecuteScalar();
                        return maxId + 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greška pri dohvatu sljedećeg DolazakId: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0; // Vraća 0 ili neku drugu vrijednost u slučaju greške
                }
            }
        }

        public bool InsertNewDolazak(int dolazakId, int dijeteId, DateTime datum, TimeSpan vrijemeDolaska, TimeSpan vrijemeOdlaska)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Dolazak (dolazak_id, dijete_id, datum, vrijeme_dolaska, vrijeme_odlaska)
                             VALUES (@dolazakId, @dijeteId, @datum, @vrijemeDolaska, @vrijemeOdlaska)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dolazakId", dolazakId);
                        cmd.Parameters.AddWithValue("@dijeteId", dijeteId);
                        cmd.Parameters.AddWithValue("@vrijemeDolaska", vrijemeDolaska);
                        cmd.Parameters.AddWithValue("@vrijemeOdlaska", (object)vrijemeOdlaska ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@datum", datum.Date);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri spremanju novog dolaska: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        public bool IsDijeteInGroup(int dijeteId, int grupaId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Dijete WHERE dijete_id = @dijeteId AND grupa_id = @grupaId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dijeteId", dijeteId);
                        cmd.Parameters.AddWithValue("@grupaId", grupaId);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri provjeri djeteta u grupi: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        public List<Dijete> GetAllChildren()
        {
            List<Dijete> djeca = new List<Dijete>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT d.dijete_id, d.ime, d.prezime, d.datum_rodenja, d.email_roditelja, g.naziv AS NazivGrupe
                        FROM Dijete d
                        INNER JOIN Grupa g ON d.grupa_id = g.grupa_id
                        ORDER BY d.prezime, d.ime";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            djeca.Add(new Dijete
                            {
                                DijeteId = reader.GetInt32(0),
                                Ime = reader.GetString(1),
                                Prezime = reader.GetString(2),
                                DatumRodenja = reader.GetDateTime(3),
                                EmailRoditelja = reader.GetString(4),
                                NazivGrupe = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri dohvatu popisa djece: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return djeca;
        }

        public List<Dijete> GetNoShowChildren(int groupId, DateTime date)
        {
            List<Dijete> noShowChildren = new List<Dijete>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT d.dijete_id, d.ime, d.prezime, d.datum_rodenja, d.email_roditelja, g.naziv AS NazivGrupe
                FROM Dijete d
                INNER JOIN Grupa g ON d.grupa_id = g.grupa_id
                LEFT JOIN Dolazak dol ON d.dijete_id = dol.dijete_id AND dol.datum = @datum
                WHERE g.grupa_id = @grupaId AND dol.dolazak_id IS NULL
                ORDER BY d.prezime, d.ime";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@grupaId", groupId);
                        cmd.Parameters.AddWithValue("@datum", date.Date);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                noShowChildren.Add(new Dijete
                                {
                                    DijeteId = reader.GetInt32(0),
                                    Ime = reader.GetString(1),
                                    Prezime = reader.GetString(2),
                                    DatumRodenja = reader.GetDateTime(3),
                                    EmailRoditelja = reader.GetString(4),
                                    NazivGrupe = reader.GetString(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri dohvatu djece koja su izostala: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return noShowChildren;
        }

    }
}
