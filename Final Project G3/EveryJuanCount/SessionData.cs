using System;
using System.Collections.Generic;

namespace EveryJuanCount
{
    public static class SessionData
    {
        // Currently logged-in resident
        public static Resident CurrentResident { get; set; } = new Resident
        {
            // Dummy data for testing (replace with real DB data later)
            FirstName = "Mark Brandon",
            MiddleName = "Velez",
            LastName = "Pine",
            DateOfBirth = new DateTime(2005, 8, 3),
            ContactNumber = "09123456789",
            Email = "brandonjosefpine@email.com",
            HouseStreet = "123 Sitio Calumpang",
            Purok = "Purok 1",
            Barangay = "Alangilan",
            Municipality = "Batangas City",
            Province = "Batangas",
            PostalCode = "4200",
            HouseholdRole = "Not Applicable",
            ResidencyStatus = "Not Applicable",
            HouseholdMembers = 0
        };

        // Password (replace with DB check later)
        public static string Password { get; set; } = "Test@1234";

        // Reports submitted by the resident
        public static List<Report> Reports { get; set; } = new List<Report>();

        // Add inside SessionData class
        public static string CurrentRole { get; set; } = "";

        public static List<(string Username, string Password, string Role)> Accounts =
            new List<(string, string, string)>
        {
            ("resident1", "Test@1234", "Resident"),
            ("staff1", "Staff@1234", "Staff")
        };
    }
}