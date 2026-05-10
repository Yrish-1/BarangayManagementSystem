using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace EveryJuanCount
{
    public static class DatabaseHelper
    {
        private static string dbPath = "EveryJuanCount.db";
        private static string connectionString => $"Data Source={dbPath}";

        #region Initialize Database
        public static void InitializeDatabase()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            // Disable foreign key enforcement
            var pragmaFK = connection.CreateCommand();
            pragmaFK.CommandText = "PRAGMA foreign_keys = OFF;";
            pragmaFK.ExecuteNonQuery();

            // Create Users table
            var createUsers = connection.CreateCommand();
            createUsers.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL
                );";
            createUsers.ExecuteNonQuery();

            // Create Residents table
            var createResidents = connection.CreateCommand();
            createResidents.CommandText = @"
                CREATE TABLE IF NOT EXISTS Residents (
                    ResidentId INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER,
                    FirstName TEXT,
                    MiddleName TEXT,
                    LastName TEXT,
                    DateOfBirth TEXT,
                    ContactNumber TEXT,
                    Email TEXT,
                    HouseStreet TEXT,
                    Purok TEXT,
                    Barangay TEXT,
                    Municipality TEXT,
                    Province TEXT,
                    PostalCode TEXT,
                    HouseholdRole TEXT,
                    ResidencyStatus TEXT,
                    HouseholdMembers INTEGER
                );";
            createResidents.ExecuteNonQuery();

            // Create Reports table
            var createReports = connection.CreateCommand();
            createReports.CommandText = @"
                CREATE TABLE IF NOT EXISTS Reports (
                    ReportId INTEGER PRIMARY KEY AUTOINCREMENT,
                    ResidentId INTEGER,
                    EventType TEXT,
                    FirstName TEXT,
                    MiddleName TEXT,
                    LastName TEXT,
                    DateOfEvent TEXT,
                    AdditionalDetails TEXT,
                    ReporterFirstName TEXT,
                    ReporterMiddleName TEXT,
                    ReporterLastName TEXT,
                    ReporterContact TEXT,
                    RelationshipToPerson TEXT,
                    UploadedIDPath TEXT,
                    Status TEXT DEFAULT 'Pending',
                    DateSubmitted TEXT,
                    AdminRemarks TEXT
                );";
            createReports.ExecuteNonQuery();

            // Create Announcements table
            var createAnnouncements = connection.CreateCommand();
            createAnnouncements.CommandText = @"
                CREATE TABLE IF NOT EXISTS Announcements (
                    AnnouncementId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT,
                    Content TEXT,
                    DatePosted TEXT,
                    PostedBy TEXT
                );";
            createAnnouncements.ExecuteNonQuery();

            // Insert default accounts
            var insertAdmin = connection.CreateCommand();
            insertAdmin.CommandText = @"
                INSERT OR IGNORE INTO Users (Username, Password, Role) VALUES
                ('resident1', 'Test@1234', 'Resident'),
                ('staff1', 'Staff@1234', 'Staff'),
                ('admin1', 'Admin@1234', 'Admin');";
            insertAdmin.ExecuteNonQuery();

            // Insert default resident record
            var insertResident = connection.CreateCommand();
            insertResident.CommandText = @"
                INSERT OR IGNORE INTO Residents (UserId, FirstName, MiddleName, LastName, 
                DateOfBirth, ContactNumber, Email, HouseStreet, Purok, Barangay, 
                Municipality, Province, PostalCode, HouseholdRole, ResidencyStatus, HouseholdMembers)
                VALUES (
                (SELECT UserId FROM Users WHERE Username = 'resident1'),
                'Mark Brandon', 'Velez', 'Pine', '2005-08-03', '09123456789',
                'brandonjosefpine@email.com', '123 Sitio Calumpang', 'Purok 1',
                'Alangilan', 'Batangas City', 'Batangas', '4200',
                'Not Applicable', 'Not Applicable', 0
                );";
            insertResident.ExecuteNonQuery();

            Console.WriteLine("Database initialized successfully!");
        }
        #endregion

        #region User Operations
        public static (bool success, string role) Login(string username, string password)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT Role FROM Users 
                WHERE Username = $username AND Password = $password";
            command.Parameters.AddWithValue("$username", username);
            command.Parameters.AddWithValue("$password", password);

            var result = command.ExecuteScalar();
            if (result != null)
                return (true, result.ToString());

            return (false, "");
        }
        #endregion

        #region Resident Operations
        public static Resident GetResident(string username)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT r.* FROM Residents r
                JOIN Users u ON r.UserId = u.UserId
                WHERE u.Username = $username";
            command.Parameters.AddWithValue("$username", username);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Resident
                {
                    FirstName = reader["FirstName"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                    ContactNumber = reader["ContactNumber"].ToString(),
                    Email = reader["Email"].ToString(),
                    HouseStreet = reader["HouseStreet"].ToString(),
                    Purok = reader["Purok"].ToString(),
                    Barangay = reader["Barangay"].ToString(),
                    Municipality = reader["Municipality"].ToString(),
                    Province = reader["Province"].ToString(),
                    PostalCode = reader["PostalCode"].ToString(),
                    HouseholdRole = reader["HouseholdRole"].ToString(),
                    ResidencyStatus = reader["ResidencyStatus"].ToString(),
                    HouseholdMembers = Convert.ToInt32(reader["HouseholdMembers"])
                };
            }
            return null;
        }

        public static int GetResidentId(string username)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT r.ResidentId FROM Residents r
                JOIN Users u ON r.UserId = u.UserId
                WHERE u.Username = $username";
            command.Parameters.AddWithValue("$username", username);

            var result = command.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }
        #endregion

        #region Report Operations
        public static void SaveReport(Report report, int residentId)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            // Disable foreign key enforcement
            var pragma = connection.CreateCommand();
            pragma.CommandText = "PRAGMA foreign_keys = OFF;";
            pragma.ExecuteNonQuery();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Reports (
                    ResidentId, EventType, FirstName, MiddleName, LastName,
                    DateOfEvent, AdditionalDetails, ReporterFirstName,
                    ReporterMiddleName, ReporterLastName, ReporterContact,
                    RelationshipToPerson, UploadedIDPath, Status, DateSubmitted
                ) VALUES (
                    $residentId, $eventType, $firstName, $middleName, $lastName,
                    $dateOfEvent, $additionalDetails, $reporterFirstName,
                    $reporterMiddleName, $reporterLastName, $reporterContact,
                    $relationshipToPerson, $uploadedIDPath, $status, $dateSubmitted
                )";

            command.Parameters.AddWithValue("$residentId", residentId);
            command.Parameters.AddWithValue("$eventType", report.EventType);
            command.Parameters.AddWithValue("$firstName", report.FirstName);
            command.Parameters.AddWithValue("$middleName", report.MiddleName ?? "");
            command.Parameters.AddWithValue("$lastName", report.LastName);
            command.Parameters.AddWithValue("$dateOfEvent", report.DateOfEvent.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("$additionalDetails", report.AdditionalDetails ?? "");
            command.Parameters.AddWithValue("$reporterFirstName", report.ReporterFirstName);
            command.Parameters.AddWithValue("$reporterMiddleName", report.ReporterMiddleName ?? "");
            command.Parameters.AddWithValue("$reporterLastName", report.ReporterLastName);
            command.Parameters.AddWithValue("$reporterContact", report.ReporterContact);
            command.Parameters.AddWithValue("$relationshipToPerson", report.RelationshipToPerson ?? "");
            command.Parameters.AddWithValue("$uploadedIDPath", report.UploadedIDPath ?? "");
            command.Parameters.AddWithValue("$status", "Pending");
            command.Parameters.AddWithValue("$dateSubmitted", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            command.ExecuteNonQuery();
        }

        public static List<Report> GetReports(int residentId, string filter = "All")
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            if (filter == "All")
            {
                command.CommandText = @"
                    SELECT * FROM Reports WHERE ResidentId = $residentId
                    ORDER BY DateSubmitted DESC";
                command.Parameters.AddWithValue("$residentId", residentId);
            }
            else
            {
                command.CommandText = @"
                    SELECT * FROM Reports WHERE ResidentId = $residentId AND Status = $status
                    ORDER BY DateSubmitted DESC";
                command.Parameters.AddWithValue("$residentId", residentId);
                command.Parameters.AddWithValue("$status", filter);
            }

            var reports = new List<Report>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                reports.Add(new Report
                {
                    ReportId = Convert.ToInt32(reader["ReportId"]),
                    EventType = reader["EventType"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    DateOfEvent = DateTime.Parse(reader["DateOfEvent"].ToString()),
                    AdditionalDetails = reader["AdditionalDetails"].ToString(),
                    ReporterFirstName = reader["ReporterFirstName"].ToString(),
                    ReporterContact = reader["ReporterContact"].ToString(),
                    Status = reader["Status"].ToString(),
                    DateSubmitted = DateTime.Parse(reader["DateSubmitted"].ToString()),
                    AdminRemarks = reader["AdminRemarks"].ToString()
                });
            }
            return reports;
        }
        #endregion
    }
}