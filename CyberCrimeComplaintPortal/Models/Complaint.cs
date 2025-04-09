using System.ComponentModel.DataAnnotations;

namespace CyberCrimeComplaintPortal.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string IncidentDetails { get; set; }

        public string status { get; set; } = "Pending"; //default

        public DateTime DateSubmitted { get; set; }

    }
}
