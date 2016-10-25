using System;
using Xunit;
using website.Services;
using website.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using website.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace website.UnitTests.Services
{
    public class HomeControllerTest : BaseTestClass
    {
        [Fact]
        public void HomeControllerIndexView()
        {
            var controller = new HomeController(this._councilService, this._councilVisitService);
            var result = controller.Index() as ViewResult;

            var model = result.Model as website.Models.ManageViewModels.HomePageViewModel;
            Assert.Equal(0, model.CouncilId);
            Assert.Equal(null, model.cVisitModel);
            Assert.Equal("Index", result.ViewName);
        }


    }
}