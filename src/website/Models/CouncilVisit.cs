using System;
using System.ComponentModel.DataAnnotations;

namespace website.Models
{
    public class CouncilVisit
    {
        public int Id { get; set; }
        public int CouncilId { get; set; }

        [Required]
        public DateTime? DoubleBookingDate { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string Comments { get; set; }

        public CouncilVisit()
        {
        }
    }
}
