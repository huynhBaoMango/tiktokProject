using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class DatabaseCode : MonoBehaviour
{
    private string dbName = "URI=file:Player.db";

    void Start()
    {
        CreateDB();
    }

    private void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS players (id VARCHAR(50), currentscore LONG, wins INT);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void AdjustCurrentScore(string id, long scoreToAdd)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            // Kiểm tra xem người chơi có trong database không
            using (var checkCommand = connection.CreateCommand())
            {
                checkCommand.CommandText = "SELECT COUNT(*) FROM players WHERE id = @id";
                checkCommand.Parameters.AddWithValue("@id", id);

                long count = (long)checkCommand.ExecuteScalar();

                if (count == 0) // Nếu người chơi chưa có, thêm vào
                {
                    using (var insertCommand = connection.CreateCommand())
                    {
                        insertCommand.CommandText = "INSERT INTO players (id, currentscore, wins) VALUES (@id, @score, 0)";
                        insertCommand.Parameters.AddWithValue("@id", id);
                        insertCommand.Parameters.AddWithValue("@score", scoreToAdd);
                        insertCommand.ExecuteNonQuery();
                    }
                }
                else // Nếu người chơi đã có, cập nhật điểm
                {
                    using (var updateCommand = connection.CreateCommand())
                    {
                        updateCommand.CommandText = "UPDATE players SET currentscore = currentscore + @score WHERE id = @id";
                        updateCommand.Parameters.AddWithValue("@id", id);
                        updateCommand.Parameters.AddWithValue("@score", scoreToAdd);
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }

            connection.Close();
        }
    }
}
