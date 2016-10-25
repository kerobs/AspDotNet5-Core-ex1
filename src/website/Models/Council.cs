using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace website.Models
{
    public class Council
    {
        public int Id { get; set; }
        public string AuthorityName { get; set; }
        public double LocalGovtElectors { get; set; }
        public double NumberOfWards { get; set; }
        public double CouncilSize { get; set; }
        public double Hectares { get; set; }
        public double ElectorsPerCouncillor { get; set; }
        public double Density { get; set; }
        public string AuthorityType { get; set; }
        public string CountyCouncilName { get; set; }
        public string ElectoralCycle { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfLastReview { get; set; }

        public string CurrentlyInReview { get; set; }
        public string PlannedReview { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdate { get; set; }

        public Council()
        {
        }

    }
}
