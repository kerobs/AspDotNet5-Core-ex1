using System;
using Xunit;
using website.Services;
using website.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace website.UnitTests.Services
{
    public class BaseTestClass
    {
        public readonly ICouncilRepository _councilService;
        public readonly ICouncilVisitRepository _councilVisitService;
        
        public BaseTestClass()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DBSERVER;Initial Catalog=_rTask;Persist Security Info=True;User ID=XXXXX;Password=XXXXXX;MultipleActiveResultSets=True;");

            var _dbContext = new MyDbContext(optionsBuilder.Options);

            _councilService = new CouncilRepository(_dbContext);
            _councilVisitService = new CouncilVisitRepository(_dbContext);

        }
   
    }
}