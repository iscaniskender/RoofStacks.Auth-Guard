using Microsoft.AspNetCore.Mvc;
using Moq;
using RoofStacks.EmployeeAPI.Controllers;
using RoofStacks.EmployeeAPI.Services;

namespace RoofStacks.Employee.Test
{
    public class EmployeesControllerTests
    {
        private readonly Mock<IEmployeeService> _mockService;
        private readonly EmployeesController _controller;

        public EmployeesControllerTests()
        {
            _mockService = new Mock<IEmployeeService>();
            _controller = new EmployeesController(_mockService.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfEmployees()
        {
            // Arrange
            _mockService.Setup(service => service.GetEmployees()).Returns(new List<EmployeeAPI.Model.Employee> { new EmployeeAPI.Model.Employee(), new EmployeeAPI.Model.Employee() });

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<EmployeeAPI.Model.Employee>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void GetById_ReturnsOkResult_WithEmployee()
        {
            // Arrange
            _mockService.Setup(service => service.GetEmployeeById(1)).Returns(new EmployeeAPI.Model.Employee());

            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_ReturnsCreatedAtActionResult_WithEmployee()
        {
            // Arrange
            var employee = new EmployeeAPI.Model.Employee();
            _mockService.Setup(service => service.AddEmployee(It.IsAny<EmployeeAPI.Model.Employee>())).Returns(employee);

            // Act
            var result = _controller.Post(employee);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void Put_ReturnsNoContentResult_WhenUpdatedSuccessfully()
        {
            // Arrange
            var employee = new EmployeeAPI.Model.Employee();
            _mockService.Setup(service => service.GetEmployeeById(It.IsAny<int>())).Returns(new EmployeeAPI.Model.Employee());

            // Act
            var result = _controller.Put(1, employee);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContentResult_WhenDeletedSuccessfully()
        {
            // Arrange
            _mockService.Setup(service => service.GetEmployeeById(It.IsAny<int>())).Returns(new EmployeeAPI.Model.Employee());

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
