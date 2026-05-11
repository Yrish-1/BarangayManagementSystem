using System;

namespace EveryJuanCount
{
    public class Report
    {
        public int ReportId { get; set; }
        public int ResidentId { get; set; }
        public string EventType { get; set; }

        // Person involved in the event
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string AdditionalDetails { get; set; }

        // Reporter information
        public string ReporterFirstName { get; set; }
        public string ReporterMiddleName { get; set; }
        public string ReporterLastName { get; set; }
        public string ReporterContact { get; set; }
        public string RelationshipToPerson { get; set; }
        public string UploadedIDPath { get; set; }

        // Status tracking
        public string Status { get; set; } = "Pending";
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
        public string AdminRemarks { get; set; }
    }
}