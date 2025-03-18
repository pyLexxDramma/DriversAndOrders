using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace DriversAndOrders
{
    public class DatabaseHelper
    {
        private const string DbFileName = "DriversAndOrders.db";
        private static readonly string ConnectionString = $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DriversAndOrders.db")};Version=3;";

        public DatabaseHelper()
        {
            if (!File.Exists(DbFileName))
            {
                CreateDatabase();
                CreateTables();
                InsertInitialData();
            }
        }

        private void CreateDatabase()
        {
            SQLiteConnection.CreateFile(DbFileName);
        }

        private void CreateTables()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string createDriversTableQuery = @"
                    CREATE TABLE Drivers (
                        DriverId INTEGER PRIMARY KEY AUTOINCREMENT,
                        DriverFullName TEXT NOT NULL,
                        DriverLicense TEXT NOT NULL,
                        CarBrand TEXT,
                        CarModel TEXT
                    );";

                string createOrdersTableQuery = @"
                    CREATE TABLE Orders (
                        OrderId INTEGER PRIMARY KEY AUTOINCREMENT,
                        DriverFullName TEXT NOT NULL,
                        DriverLicense TEXT NOT NULL,
                        CarBrandAndModel TEXT,
                        DepartureAddress TEXT NOT NULL,
                        DestinationAddress TEXT NOT NULL,
                        StartTime DATETIME NOT NULL,
                        Status INTEGER NOT NULL
                    );";

                using (var command = new SQLiteCommand(createDriversTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createOrdersTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InsertInitialData()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // Insert initial drivers
                ExecuteNonQuery(connection, "INSERT INTO Drivers (DriverFullName, DriverLicense, CarBrand, CarModel) VALUES ('Иванов Иван Иванович', '1234 ABC', 'Toyota', 'Corolla');");
                ExecuteNonQuery(connection, "INSERT INTO Drivers (DriverFullName, DriverLicense, CarBrand, CarModel) VALUES ('Петров Петр Петрович', '5678 DEF', 'BMW', 'X5');");
                ExecuteNonQuery(connection, "INSERT INTO Drivers (DriverFullName, DriverLicense, CarBrand, CarModel) VALUES ('Сидоров Сидор Сидорович', '9012 GHI', 'Mercedes', 'C-Class');");
                ExecuteNonQuery(connection, "INSERT INTO Drivers (DriverFullName, DriverLicense, CarBrand, CarModel) VALUES ('Смирнов Алексей Иванович', '3456 JKL', 'Audi', 'A6');");
                ExecuteNonQuery(connection, "INSERT INTO Drivers (DriverFullName, DriverLicense, CarBrand, CarModel) VALUES ('Кузнецов Дмитрий Петрович', '7890 MNO', 'Volkswagen', 'Passat');");

                // Insert initial orders
                ExecuteNonQuery(connection, "INSERT INTO Orders (DriverFullName, DriverLicense, CarBrandAndModel, DepartureAddress, DestinationAddress, StartTime, Status) VALUES ('Иванов Иван Иванович', '1234 ABC', 'Toyota Corolla', 'ул. Ленина, 1', 'ул. Мира, 2', '2024-01-20 10:00:00', 1);");
                ExecuteNonQuery(connection, "INSERT INTO Orders (DriverFullName, DriverLicense, CarBrandAndModel, DepartureAddress, DestinationAddress, StartTime, Status) VALUES ('Петров Петр Петрович', '5678 DEF', 'BMW X5', 'ул. Пушкина, 3', 'ул. Лермонтова, 4', '2024-01-20 11:00:00', 1);");
                ExecuteNonQuery(connection, "INSERT INTO Orders (DriverFullName, DriverLicense, CarBrandAndModel, DepartureAddress, DestinationAddress, StartTime, Status) VALUES ('Сидоров Сидор Сидорович', '9012 GHI', 'Mercedes C-Class', 'ул. Гагарина, 5', 'ул. Королева, 6', '2024-01-20 12:00:00', 1);");
                ExecuteNonQuery(connection, "INSERT INTO Orders (DriverFullName, DriverLicense, CarBrandAndModel, DepartureAddress, DestinationAddress, StartTime, Status) VALUES ('Иванов Иван Иванович', '1234 ABC', 'Toyota Corolla', 'пр. Победы, 7', 'ул. Юбилейная, 8', '2024-01-19 13:00:00', 0);");
                ExecuteNonQuery(connection, "INSERT INTO Orders (DriverFullName, DriverLicense, CarBrandAndModel, DepartureAddress, DestinationAddress, StartTime, Status) VALUES ('Петров Петр Петрович', '5678 DEF', 'BMW X5', 'ул. Строителей, 9', 'ул. Космонавтов, 10', '2024-01-19 14:00:00', 0);");
                ExecuteNonQuery(connection, "INSERT INTO Orders (DriverFullName, DriverLicense, CarBrandAndModel, DepartureAddress, DestinationAddress, StartTime, Status) VALUES ('Сидоров Сидор Сидорович', '9012 GHI', 'Mercedes C-Class', 'ул. Энтузиастов, 11', 'ул. Молодежная, 12', '2024-01-19 15:00:00', 0);");
                ExecuteNonQuery(connection, "INSERT INTO Orders (DriverFullName, DriverLicense, CarBrandAndModel, DepartureAddress, DestinationAddress, StartTime, Status) VALUES ('Смирнов Алексей Иванович', '3456 JKL', 'Audi A6', 'ул. 8 Марта, 13', 'ул. Маяковского, 14', '2024-01-19 16:00:00', 0);");
            }
        }

        private void ExecuteNonQuery(SQLiteConnection connection, string query)
        {
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<Driver> GetDrivers()
        {
            List<Driver> drivers = new List<Driver>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT DriverId, DriverFullName, DriverLicense, CarBrand, CarModel FROM Drivers;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            drivers.Add(new Driver
                            {
                                DriverId = Convert.ToInt32(reader["DriverId"]),
                                DriverFullName = reader["DriverFullName"].ToString(),
                                DriverLicense = reader["DriverLicense"].ToString(),
                                CarBrand = reader["CarBrand"].ToString(),
                                CarModel = reader["CarModel"].ToString()
                            });
                        }
                    }
                }
            }

            return drivers;
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT OrderId, DriverFullName, DriverLicense, CarBrandAndModel, DepartureAddress, DestinationAddress, StartTime, Status FROM Orders;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderId = Convert.ToInt32(reader["OrderId"]),
                                DriverFullName = reader["DriverFullName"].ToString(),
                                DriverLicense = reader["DriverLicense"].ToString(),
                                CarBrandAndModel = reader["CarBrandAndModel"].ToString(),
                                DepartureAddress = reader["DepartureAddress"].ToString(),
                                DestinationAddress = reader["DestinationAddress"].ToString(),
                                StartTime = Convert.ToDateTime(reader["StartTime"]),
                                Status = Convert.ToBoolean(Convert.ToInt32(reader["Status"]))
                            });
                        }
                    }
                }
            }

            return orders;
        }

        public void AddDriver(Driver driver)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Drivers (DriverFullName, DriverLicense, CarBrand, CarModel) VALUES (@DriverFullName, @DriverLicense, @CarBrand, @CarModel);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverFullName", driver.DriverFullName);
                    command.Parameters.AddWithValue("@DriverLicense", driver.DriverLicense);
                    command.Parameters.AddWithValue("@CarBrand", driver.CarBrand);
                    command.Parameters.AddWithValue("@CarModel", driver.CarModel);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDriver(Driver driver)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Drivers SET DriverFullName = @DriverFullName, DriverLicense = @DriverLicense, CarBrand = @CarBrand, CarModel = @CarModel WHERE DriverId = @DriverId;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverId", driver.DriverId);
                    command.Parameters.AddWithValue("@DriverFullName", driver.DriverFullName);
                    command.Parameters.AddWithValue("@DriverLicense", driver.DriverLicense);
                    command.Parameters.AddWithValue("@CarBrand", driver.CarBrand);
                    command.Parameters.AddWithValue("@CarModel", driver.CarModel);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDriver(int driverId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Drivers WHERE DriverId = @DriverId;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverId", driverId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddOrder(Order order)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Orders (DriverFullName, DriverLicense, CarBrandAndModel, DepartureAddress, DestinationAddress, StartTime, Status) VALUES (@DriverFullName, @DriverLicense, @CarBrandAndModel, @DepartureAddress, @DestinationAddress, @StartTime, @Status);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverFullName", order.DriverFullName);
                    command.Parameters.AddWithValue("@DriverLicense", order.DriverLicense);
                    command.Parameters.AddWithValue("@CarBrandAndModel", order.CarBrandAndModel);
                    command.Parameters.AddWithValue("@DepartureAddress", order.DepartureAddress);
                    command.Parameters.AddWithValue("@DestinationAddress", order.DestinationAddress);
                    command.Parameters.AddWithValue("@StartTime", order.StartTime);
                    command.Parameters.AddWithValue("@Status", order.Status);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Orders SET DriverFullName = @DriverFullName, DriverLicense = @DriverLicense, CarBrandAndModel = @CarBrandAndModel, DepartureAddress = @DepartureAddress, DestinationAddress = @DestinationAddress, StartTime = @StartTime, Status = @Status WHERE OrderId = @OrderId;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", order.OrderId);
                    command.Parameters.AddWithValue("@DriverFullName", order.DriverFullName);
                    command.Parameters.AddWithValue("@DriverLicense", order.DriverLicense);
                    command.Parameters.AddWithValue("@CarBrandAndModel", order.CarBrandAndModel);
                    command.Parameters.AddWithValue("@DepartureAddress", order.DepartureAddress);
                    command.Parameters.AddWithValue("@DestinationAddress", order.DestinationAddress);
                    command.Parameters.AddWithValue("@StartTime", order.StartTime);
                    command.Parameters.AddWithValue("@Status", order.Status);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Orders WHERE OrderId = @OrderId;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateOrdersForDriverUpdate(int driverId, string newDriverFullName, string newDriverLicense, string newCarBrand, string newCarModel)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = @"
                    UPDATE Orders 
                    SET DriverFullName = @NewDriverFullName, 
                        DriverLicense = @NewDriverLicense, 
                        CarBrandAndModel = @NewCarBrandAndModel
                    WHERE DriverLicense IN (SELECT DriverLicense FROM Drivers WHERE DriverId = @DriverId) AND Status = 1;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverId", driverId);
                    command.Parameters.AddWithValue("@NewDriverFullName", newDriverFullName);
                    command.Parameters.AddWithValue("@NewDriverLicense", newDriverLicense);
                    command.Parameters.AddWithValue("@NewCarBrandAndModel", $"{newCarBrand} {newCarModel}");

                    command.ExecuteNonQuery();
                }
            }
        }


        public void DeleteOrdersForDriverDeletion(int driverId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = @"
                    UPDATE Orders 
                    SET DriverFullName = '', 
                        DriverLicense = '', 
                        CarBrandAndModel = ''
                    WHERE DriverLicense IN (SELECT DriverLicense FROM Drivers WHERE DriverId = @DriverId) AND Status = 1;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverId", driverId);
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}