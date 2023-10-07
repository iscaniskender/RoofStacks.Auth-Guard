using Microsoft.AspNetCore.Mvc;
using RoofStacks.CompanyAPI.Controllers;
using RoofStacks.CompanyAPI.Model;
using RoofStacks.CompanyAPI.Services;
using Moq;

namespace RoofStacks.CompanyAPI.Test
{
    

    namespace RoofStacks.CompanyAPI.Tests
    {
        public class CompaniesControllerTests
        {
            private readonly Mock<ICompanyService> _mockService;
            private readonly CompaniesController _controller;

            public CompaniesControllerTests()
            {
                _mockService = new Mock<ICompanyService>();
                _controller = new CompaniesController(_mockService.Object);
            }

            [Fact]
            public void Get_ReturnsOkResult_WithListOfCompanies()
            {
                // Arrange
                _mockService.Setup(service => service.GetCompanys()).Returns(new List<Company> { new Company(), new Company() });

                // Act
                var result = _controller.Get();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnValue = Assert.IsType<List<Company>>(okResult.Value);
                Assert.Equal(2, returnValue.Count);
            }

            [Fact]
            public void GetById_ReturnsOkResult_WithCompany()
            {
                // Arrange
                _mockService.Setup(service => service.GetCompanyById(1)).Returns(new Company());

                // Act
                var result = _controller.Get(1);

                // Assert
                Assert.IsType<OkObjectResult>(result);
            }

            [Fact]
            public void Post_ReturnsCreatedAtActionResult_WithCompany()
            {
                // Arrange
                var company = new Company
                {

                    Address = "xUnitTest",
                    Industry = "xUnitTest",
                    Name = "xUnitTest",
                };
                _mockService.Setup(service => service.AddCompany(It.IsAny<Company>())).Returns(company);

                // Act
                var result = _controller.Post(company);

                // Assert
                Assert.IsType<CreatedAtActionResult>(result);
            }

            [Fact]
            public void Put_ReturnsNoContentResult_WhenUpdatedSuccessfully()
            {
                // Arrange
                var company = new Company();
                
                _mockService.Setup(service => service.GetCompanyById(It.IsAny<int>())).Returns(new Company());
                
                _mockService.Setup(service => service.UpdateCompany(It.IsAny<Company>()));

                // Act
                var result = _controller.Put(1, company);

                // Assert
                Assert.IsType<NoContentResult>(result);
            }


            [Fact]
            public void Delete_ReturnsNoContentResult_WhenDeletedSuccessfully()
            {
                // Arrange
                _mockService.Setup(service => service.GetCompanyById(1)).Returns(new Company());

                // Act
                var result = _controller.Delete(1);

                // Assert
                Assert.IsType<NoContentResult>(result);
            }
        }
    }

}