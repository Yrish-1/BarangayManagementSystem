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

        #region Registration Operations
        public static bool RegisterResident(string username, string password,
            string firstName, string middleName, string lastName,
            DateTime dateOfBirth, string contactNumber, string email,
            string houseStreet, string purok, string barangay,
            string municipality, string province, string postalCode,
            string householdRole, string residencyStatus, int householdMembers)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var pragma = connection.CreateCommand();
            pragma.CommandText = "PRAGMA foreign_keys = OFF;";
            pragma.ExecuteNonQuery();

            // Check if username already exists
            var checkUser = connection.CreateCommand();
            checkUser.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = $username";
            checkUser.Parameters.AddWithValue("$username", username);
            int count = Convert.ToInt32(checkUser.ExecuteScalar());
            if (count > 0) return false;

            // Insert user
            var insertUser = connection.CreateCommand();
            insertUser.CommandText = @"
        INSERT INTO Users (Username, Password, Role) 
        VALUES ($username, $password, 'Resident')";
            insertUser.Parameters.AddWithValue("$username", username);
            insertUser.Parameters.AddWithValue("$password", password);
            insertUser.ExecuteNonQuery();

            // Get new UserId
            var getUserId = connection.CreateCommand();
            getUserId.CommandText = "SELECT last_insert_rowid()";
            int userId = Convert.ToInt32(getUserId.ExecuteScalar());

            // Insert resident
            var insertResident = connection.CreateCommand();
            insertResident.CommandText = @"
        INSERT INTO Residents (UserId, FirstName, MiddleName, LastName,
            DateOfBirth, ContactNumber, Email, HouseStreet, Purok, Barangay,
            Municipality, Province, PostalCode, HouseholdRole, ResidencyStatus, HouseholdMembers)
        VALUES ($userId, $firstName, $middleName, $lastName,
            $dateOfBirth, $contactNumber, $email, $houseStreet, $purok, $barangay,
            $municipality, $province, $postalCode, $householdRole, $residencyStatus, $householdMembers)";

            insertResident.Parameters.AddWithValue("$userId", userId);
            insertResident.Parameters.AddWithValue("$firstName", firstName);
            insertResident.Parameters.AddWithValue("$middleName", middleName ?? "");
            insertResident.Parameters.AddWithValue("$lastName", lastName);
            insertResident.Parameters.AddWithValue("$dateOfBirth", dateOfBirth.ToString("yyyy-MM-dd"));
            insertResident.Parameters.AddWithValue("$contactNumber", contactNumber ?? "");
            insertResident.Parameters.AddWithValue("$email", email ?? "");
            insertResident.Parameters.AddWithValue("$houseStreet", houseStreet ?? "");
            insertResident.Parameters.AddWithValue("$purok", purok ?? "");
            insertResident.Parameters.AddWithValue("$barangay", barangay ?? "");
            insertResident.Parameters.AddWithValue("$municipality", municipality ?? "");
            insertResident.Parameters.AddWithValue("$province", province ?? "");
            insertResident.Parameters.AddWithValue("$postalCode", postalCode ?? "");
            insertResident.Parameters.AddWithValue("$householdRole", householdRole ?? "Not Applicable");
            insertResident.Parameters.AddWithValue("$residencyStatus", residencyStatus ?? "Not Applicable");
            insertResident.Parameters.AddWithValue("$householdMembers", householdMembers);
            insertResident.ExecuteNonQuery();

            return true;
        }
        #endregion

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

        #region Admin / Staff Operations

        public static List<(int UserId, string Username, string Role)> GetAllStaff()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT UserId, Username, Role FROM Users WHERE Role = 'Staff' ORDER BY Username";
            var list = new List<(int, string, string)>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
                list.Add((Convert.ToInt32(reader["UserId"]), reader["Username"].ToString(), reader["Role"].ToString()));
            return list;
        }

        public static bool AddStaff(string username, string password)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var check = connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = $u";
            check.Parameters.AddWithValue("$u", username);
            if (Convert.ToInt32(check.ExecuteScalar()) > 0) return false;

            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Users (Username, Password, Role) VALUES ($u, $p, 'Staff')";
            cmd.Parameters.AddWithValue("$u", username);
            cmd.Parameters.AddWithValue("$p", password);
            cmd.ExecuteNonQuery();
            return true;
        }

        public static bool DeleteUser(int userId)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Users WHERE UserId = $id";
            cmd.Parameters.AddWithValue("$id", userId);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool ResetPassword(int userId, string newPassword)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Users SET Password = $p WHERE UserId = $id";
            cmd.Parameters.AddWithValue("$p", newPassword);
            cmd.Parameters.AddWithValue("$id", userId);
            return cmd.ExecuteNonQuery() > 0;
        }
        #endregion

        #region All Residents (Admin/Staff)
        public static List<Resident> GetAllResidents()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
        SELECT r.*, u.Username FROM Residents r
        JOIN Users u ON r.UserId = u.UserId
        ORDER BY r.LastName, r.FirstName";
            var list = new List<Resident>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Resident
                {
                    ResidentId = Convert.ToInt32(reader["ResidentId"]),
                    FirstName = reader["FirstName"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    DateOfBirth = DateTime.TryParse(reader["DateOfBirth"].ToString(), out var dob) ? dob : DateTime.MinValue,
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
                });
            }
            return list;
        }
        #endregion

        #region All Reports (Admin)
        public static List<Report> GetAllReports(string filter = "All")
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            if (filter == "All")
                command.CommandText = "SELECT * FROM Reports ORDER BY DateSubmitted DESC";
            else
            {
                command.CommandText = "SELECT * FROM Reports WHERE Status = $status ORDER BY DateSubmitted DESC";
                command.Parameters.AddWithValue("$status", filter);
            }
            var list = new List<Report>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Report
                {
                    ReportId = Convert.ToInt32(reader["ReportId"]),
                    EventType = reader["EventType"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    DateOfEvent = DateTime.TryParse(reader["DateOfEvent"].ToString(), out var d) ? d : DateTime.MinValue,
                    AdditionalDetails = reader["AdditionalDetails"].ToString(),
                    ReporterFirstName = reader["ReporterFirstName"].ToString(),
                    ReporterLastName = reader["ReporterLastName"].ToString(),
                    ReporterContact = reader["ReporterContact"].ToString(),
                    RelationshipToPerson = reader["RelationshipToPerson"].ToString(),
                    UploadedIDPath = reader["UploadedIDPath"].ToString(),
                    Status = reader["Status"].ToString(),
                    DateSubmitted = DateTime.TryParse(reader["DateSubmitted"].ToString(), out var ds) ? ds : DateTime.MinValue,
                    AdminRemarks = reader["AdminRemarks"].ToString()
                });
            }
            return list;
        }

        public static bool UpdateReportStatus(int reportId, string status, string remarks)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Reports SET Status = $s, AdminRemarks = $r WHERE ReportId = $id";
            cmd.Parameters.AddWithValue("$s", status);
            cmd.Parameters.AddWithValue("$r", remarks ?? "");
            cmd.Parameters.AddWithValue("$id", reportId);
            return cmd.ExecuteNonQuery() > 0;
        }
        #endregion

        #region Announcements
        public static List<(int Id, string Title, string Content, string DatePosted, string PostedBy)> GetAnnouncements()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Announcements ORDER BY DatePosted DESC";
            var list = new List<(int, string, string, string, string)>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add((
                    Convert.ToInt32(reader["AnnouncementId"]),
                    reader["Title"].ToString(),
                    reader["Content"].ToString(),
                    reader["DatePosted"].ToString(),
                    reader["PostedBy"].ToString()
                ));
            return list;
        }

        public static void AddAnnouncement(string title, string content, string postedBy)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO Announcements (Title, Content, DatePosted, PostedBy)
                        VALUES ($t, $c, $d, $p)";
            cmd.Parameters.AddWithValue("$t", title);
            cmd.Parameters.AddWithValue("$c", content);
            cmd.Parameters.AddWithValue("$d", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("$p", postedBy);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteAnnouncement(int id)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Announcements WHERE AnnouncementId = $id";
            cmd.Parameters.AddWithValue("$id", id);
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region Population Stats
        public static (int Total, int Male, int Female, int Children, int Adults, int Seniors) GetPopulationStats()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            int total = 0, children = 0, adults = 0, seniors = 0;

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT DateOfBirth FROM Residents";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                total++;
                if (DateTime.TryParse(reader["DateOfBirth"].ToString(), out var dob))
                {
                    int age = DateTime.Today.Year - dob.Year;
                    if (DateTime.Today < dob.AddYears(age)) age--;
                    if (age < 18) children++;
                    else if (age >= 60) seniors++;
                    else adults++;
                }
            }
            return (total, 0, 0, children, adults, seniors);
        }

        public static Dictionary<string, int> GetReportCountsByType()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT EventType, COUNT(*) as Count FROM Reports GROUP BY EventType";
            var dict = new Dictionary<string, int>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                dict[reader["EventType"].ToString()] = Convert.ToInt32(reader["Count"]);
            return dict;
        }
        #endregion

        #region Admin Password
        public static bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var verify = connection.CreateCommand();
            verify.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = $u AND Password = $p";
            verify.Parameters.AddWithValue("$u", username);
            verify.Parameters.AddWithValue("$p", currentPassword);
            if (Convert.ToInt32(verify.ExecuteScalar()) == 0) return false;

            var update = connection.CreateCommand();
            update.CommandText = "UPDATE Users SET Password = $np WHERE Username = $u";
            update.Parameters.AddWithValue("$np", newPassword);
            update.Parameters.AddWithValue("$u", username);
            update.ExecuteNonQuery();
            return true;
        }
        #endregion
    }
}