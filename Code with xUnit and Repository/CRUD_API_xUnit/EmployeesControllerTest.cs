using CRUD.API.Contracts;
using CRUD.API.Controllers;
using CRUD.API.Domain;
using CRUD.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Web.Http.Results;
using Xunit;


namespace CRUD.API_xUnit
{
    public class EmployeesControllerTest
    {
        EmployeesController _controller;
        IEmployeeService _service;
       
        public EmployeesControllerTest()
        {
            _service = new EmployeeServiceFake();
            _controller = new EmployeesController(_service);
           
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetEmployees();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetEmployees().Result as ObjectResult;
            // Assert
            var items = Assert.IsType<List<Employee>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetEmployee(99);

            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = 100;

            // Act
            var okResult = _controller.GetEmployee(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = 100;

            // Act
            var okResult = _controller.GetEmployee(testGuid).Result as OkObjectResult;

            // Assert
            Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(100, (okResult.Value as Employee).Id);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var newEmployee = new Employee()
            {
                Description = "Test"
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            _controller.ModelState.AddModelError("Name", "Required");
            var badResponse = _controller.PostEmployee(newEmployee);

            // Assert

            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Employee testItem = new Employee()
            {
                Id = 999,
                Name = "Ninety nine",
                Description = "description."
            };

            // Act
            var createdResponse = _controller.PostEmployee(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testEmp = new Employee()
            {
                Id=900,
                Description="test description",
                Name="test name"
            };

            // Act
            var createdResponse = _controller.PostEmployee(testEmp) as CreatedAtActionResult;
            var item = createdResponse.Value as Employee;

            // Assert
            Assert.IsType<Employee>(item);
            Assert.Equal("test name", item.Name);
        }

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 800;

            // Act
            var badResponse = _controller.DeleteEmployee(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingId = 100;

            // Act
            var okResponse = _controller.DeleteEmployee(existingId);

            // Assert
            Assert.IsType<OkObjectResult>(okResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var existingId = 100;

            // Act
            var okResponse = _controller.DeleteEmployee(existingId);

            // Assert
            Assert.Equal(4, _service.GetAllEmployeess().Count());
        }
    }
}
