using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;
using System.Data;

namespace website.Services
{
    public interface ICouncilVisitRepository
    {
        bool AddUpdateCouncilVisit(CouncilVisit ob);
        CouncilVisit getCouncilVisitById(int Id);
        CouncilVisit getCouncilVisitByParams(int CouncilId, DateTime sDate);
        Task<dynamic> getCouncilVisitDoubleBookingReport();
        void GetLocalAuthorityDoubleBookingStats(Microsoft.AspNetCore.Http.HttpContext context);
    }
}
