using System;

namespace EveryJuanCount
{
    public class Resident
    {
        // Personal Information
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => CalculateAge();
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int ResidentId { get; set; }

        // Address / Household
        public string HouseStreet { get; set; }
        public string Purok { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string HouseholdRole { get; set; }
        public string ResidencyStatus { get; set; }
        public int HouseholdMembers { get; set; }

        // Auto-compute age from DateOfBirth
        private int CalculateAge()
        {
            var today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}