using System;
using Xunit;
using website.Services;
using website.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace website.UnitTests.Services
{
    public class CouncilService_Test : BaseTestClass
    {

        [Fact]
        public void CompareAuthorityReturnValueForId1()
        {
            var result = _councilService.getCouncilById(1);
            Assert.Equal(result.AuthorityName, "Adur");
            Assert.Equal(result.CountyCouncilName, "West Sussex");
        }

        
    }
}