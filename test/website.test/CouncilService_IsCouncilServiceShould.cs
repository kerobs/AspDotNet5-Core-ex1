using System;
using Xunit;
using website.Services;
using website.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace website.UnitTests.Services
{
    public class CouncilService_IsCouncilServiceShould
    {
        private readonly ICouncilRepository _councilService;
        private readonly ICouncilVisitRepository _councilVisitService;
        
        public CouncilService_IsCouncilServiceShould()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DBSERVER;Initial Catalog=_rTask;Persist Security Info=True;User ID=XXXXXXXXXXXXX;Password=XXXXX;MultipleActiveResultSets=True;");

            var _dbContext = new MyDbContext(optionsBuilder.Options);

            _councilService = new CouncilRepository(_dbContext);
            _councilVisitService = new CouncilVisitRepository(_dbContext);

        }

        [Fact]
        public void CompareAuthorityReturnValueForId1()
        {
            var result = _councilService.getCouncilById(1);
            Assert.Equal(result.AuthorityName, "Adur");
            Assert.Equal(result.CountyCouncilName, "West Sussex");
        }

        
    }
}