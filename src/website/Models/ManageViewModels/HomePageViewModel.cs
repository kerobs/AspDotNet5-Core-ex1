using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace website.Models.ManageViewModels
{
    public class HomePageViewModel
    {
        public int CouncilId { get; set; }
        public string AuthorityName { get; set; }
        public IEnumerable<Council> councilList { get; set; }
        public CouncilVisit cVisitModel { get; set; }
    }
}
