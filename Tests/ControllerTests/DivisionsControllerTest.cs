using System;
using System.Linq;
using System.Threading.Tasks;
using Common;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.Helpings;
using OD_Stat.Modules.Divisions;
using Tests.DemoData;
using Tests.ToolsTests;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests.ControllerTests
{
    public class DivisionsControllerTest
    {
        private readonly DivisionsController _controller;
        private readonly Creators _creators;

        public DivisionsControllerTest()
        {
            var diServiceBuilder = new DIServiceBuilder();
            _controller = diServiceBuilder.GetService<DivisionsController>();    
            _creators = new Creators();
        }

        [Fact]
        public async Task  GetDivision_Ok_Test()
        {
            var division = await _creators.DivisionCreator.CreateOne();
            var result = (await _controller.Get(division.Id)).Cast<DivisionViewModelGet>();
            Assert.AreEqual(division.Id, result.Id);
        }

        [Fact]
        public async Task Search_Ok_Test()
        {
            var divisions = await _creators.DivisionCreator.CreateMany(10);
            var result = await _controller.Search(new DivisionBaseSearchParams()
            {
                Word = divisions.First().Name
            });
            Assert.IsTrue( result.Cast<PageView<DivisionViewModelList>>()
                            .Items.Any());
        }

        [Fact]
        public async Task Add_Ok_Test()
        {
            var divisionViewModel = new DivisionViewModelPost()
            {
                Name = "divisonName",
                FiasId = (await _creators.AddressCreator.CreateOne()).SettlementFiasId,
                DivisionType = DivisionType.Area,
                DirectorUserId = ( await _creators.UserCreator.CreateOne()).Id,
            };
            var result = (await _controller.Post(divisionViewModel))
                .Cast<DivisionViewModelGet>();
            Assert.IsTrue(result.Id != 0);
            Assert.IsTrue(result.Name == "divisonName");
        }

        [Fact]
        public async Task Update_Ok_Test()
        {
            var division = await _creators.DivisionCreator.CreateOne();
            var rndString = Guid.NewGuid().ToString();
            var divisionViewModel = new DivisionViewModelPost()
            {
                Name = rndString,
                DivisionType = division.DivisionType,
                FiasId = division.Address.FiasId,
                DirectorUserId = division.DirectorUserId,
                ParentDivisionId = division.ParentDivisionId
            };
            var result = (await _controller.Put(division.Id, divisionViewModel) as ObjectResult)
                .Cast<DivisionViewModelGet>();
            Assert.IsTrue(result.Id != 0);
            // Assert.AreEqual(rndString, result.Name);
            // Assert.IsTrue(result.AddressId != 0);
        }

        [Fact]
        public async Task Delete_Ok_Test()
        {
            var division = await _creators.DivisionCreator.CreateOne();
            var result = (await _controller.Delete(division.Id) as ObjectResult).Cast<string>();
            Assert.AreEqual("Deleted", result);
        }
        
        [Fact]
        public async Task Delete_Invalid_Id_Test()
        {
            (await _controller.Delete(9999999))
                .Should().BeOfType(typeof(NotFoundObjectResult));
        }
    }
}