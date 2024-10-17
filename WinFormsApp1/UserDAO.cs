using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;  // Make sure this is included for MessageBox

namespace WinFormsApp1
{
    internal class UserDAO
    {
        public List<User> Users = new List<User>();
        string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=AppDB";

        public void checkUser()
        {
            var connection = new NpgsqlConnection(connectionString);

            using (connection)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM public.person";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = new User()
                                {
                                    id = reader.GetInt32(3),  // Assuming id is an integer in your database
                                    name = reader.GetString(0),
                                    dateOfBirth = reader.GetDateTime(1),  // Use GetDateTime to handle date types
                                    gender = reader.GetString(2),
                                };
                                Users.Add(user);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions and display error message
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}
