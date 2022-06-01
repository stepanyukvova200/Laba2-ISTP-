using Laba2Empty;
using Laba2Empty.Controllers;
using Laba2Empty.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Laba2Empty.Tests
{
    public class UnitTest1
    {
        private static Laba2EmptyContext ForTest()
        {
            var options = new DbContextOptionsBuilder<Laba2EmptyContext>().UseInMemoryDatabase(databaseName: "Laba2")
                .Options;
            Laba2EmptyContext yaa = new Laba2EmptyContext(options);
            return yaa;
        }
        [Fact]
        public async void IndexViewDataMessage()
        {
            using var context = ForTest();
            // Arrange
            CategoriesController controller = new CategoriesController(context);
            CategoriesController category = new CategoriesController();
            var result = await controller.PostCategory("");

            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }

        [Fact]
        public void IndexViewResultNotNull()
        {
            // Arrange
            CategoriesController controller = new CategoriesController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexViewNameEqualIndex()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.Equal("Index", result?.ViewName);
        }
    }
}