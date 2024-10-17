using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class RestauranteDAO
    {
       public List<Restaurant> restaurants = new List<Restaurant>();

        string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=AppDB";

        public void GetRestaurantsFromDatabase()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // Open connection
                    connection.Open();

                    // Define query
                    string query = "SELECT * FROM restaurant";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Execute query
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create a Restaurant object for each row
                                var restaurant = new Restaurant
                                {
                                    id = reader.GetInt32(0),   // Assuming the first column is an integer (Id)
                                    restaurantName = reader.GetString(1), // Assuming the second column is a string (restaurant name)
                                    restaurantAddress = reader.GetString(2),
                                    imagePath = reader.GetString(3) // Assuming there's a path for the image
                                };

                                // Add the restaurant object to the list
                                restaurants.Add(restaurant);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
