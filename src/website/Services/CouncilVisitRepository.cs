using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;
using website.Data;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace website.Services
{
    public class CouncilVisitRepository : ICouncilVisitRepository
    {
        private readonly MyDbContext _dbContext;

        public CouncilVisitRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddUpdateCouncilVisit(CouncilVisit ob)
        {
            if (ob == null) { return false; }
            if (ob.Id > 0)
            {
                _dbContext.CouncilVisits.Update(ob);
            }
            else { _dbContext.CouncilVisits.Add(ob); }

            _dbContext.SaveChanges();
            return true;
        }

        public CouncilVisit getCouncilVisitById(int Id)
        {
            return _dbContext.CouncilVisits.Where(x => x.Id == Id).FirstOrDefault();
        }

        public CouncilVisit getCouncilVisitByParams(int CouncilId, DateTime sDate)
        {
            return _dbContext.CouncilVisits.Where(x => x.CouncilId == CouncilId && Convert.ToDateTime(x.UpdatedOn).Date == sDate.Date).FirstOrDefault();
        }

        public async Task<dynamic> getCouncilVisitDoubleBookingReport()
        {
            using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = @"select c.AuthorityName, c.CountyCouncilName, cv.DoubleBookingDate, cv.UpdatedOn, cv.Comments, cv.UpdatedBy from Councils c
                                    right join CouncilVisits cv
                                    on c.Id = cv.CouncilId                                    
                                    order by c.AuthorityName";

                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                var retObject = new List<dynamic>();

                using (var dataReader = await cmd.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        var dataRow = new ExpandoObject() as IDictionary<string, object>;
                        for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                        {
                            dataRow.Add(
                                dataReader.GetName(iFiled),
                                dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                            );
                        }

                        retObject.Add((ExpandoObject)dataRow);
                    }
                }
                return retObject;

            }
        }

        public void GetLocalAuthorityDoubleBookingStats(Microsoft.AspNetCore.Http.HttpContext context)
        {
            string attachment = "attachment; filename=CouncilBooking.csv";
            context.Response.Clear();
            context.Response.Headers.Clear();
            context.Response.Headers.Add("content-disposition", attachment);
            context.Response.ContentType = "text/csv";
            context.Response.Headers.Add("Pragma", "public");

            string[] sHeader = { "Authority Name", "County Council Name", "Dates the double booking occurred on", "Updated on", "Comments by", "Updated by Search Clerks" };
            for (int i = 0; i < sHeader.Length; i++)
            {
                context.Response.WriteAsync(sHeader[i] + ","); ;
            }

            Task<dynamic> olist = getCouncilVisitDoubleBookingReport();

            context.Response.WriteAsync(Environment.NewLine);
            foreach (var ob in olist.Result)
            {
                string authorityName = ob.AuthorityName;
                string CountyCouncilName = ob.CountyCouncilName;
                string DoubleBookingDate = ob.DoubleBookingDate == null ? "" : Convert.ToDateTime(ob.DoubleBookingDate).ToString("dd.MM.yyyy");
                string UpdatedOn = ob.UpdatedOn == null ? "" : Convert.ToDateTime(ob.UpdatedOn).ToString("dd.MM.yyyy");
                string Comments = ob.Comments;
                string UpdatedBy = ob.UpdatedBy;

                context.Response.WriteAsync(authorityName == null ? "," : "\"" + authorityName + "\"" + ",");
                context.Response.WriteAsync(CountyCouncilName == null ? "," : "\"" + CountyCouncilName + "\"" + ",");
                context.Response.WriteAsync("\"" + DoubleBookingDate + "\"" + ",");
                context.Response.WriteAsync("\"" + UpdatedOn + "\"" + ",");
                context.Response.WriteAsync(Comments == null ? "," : "\"" + Comments + "\"" + ",");
                context.Response.WriteAsync(UpdatedBy == null ? "," : "\"" + UpdatedBy + "\"" + ",");
                context.Response.WriteAsync(Environment.NewLine);
            }

            return;
        }






    }

}
