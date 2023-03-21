using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MileStone4StudentCrud_MongoDb.Commands;
using MileStone4StudentCrud_MongoDb.Controllers;
using MileStone4StudentCrud_MongoDb.Models;
using MileStone4StudentCrud_MongoDb.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MileStone4StudentCrud_MongoDb.Tests
{
    public class StudentControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new StudentController(_mockMediator.Object);
        }

        [Fact]
        public async Task GetAllStudents_ReturnsListOfStudents()
        {
            // Arrange
            var students = new List<Student> { 
                new Student{id = "1", StudentName = "John", StudentAddress = "Bangalore", StudentAge = 21, StudentCourse = "Ruby", StudentGender = "Male"}, 
                new Student{id = "2", StudentName = "Pavan", StudentAddress = "Guntur", StudentAge = 22, StudentCourse = "Java", StudentGender = "Male"}
            };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetStudentQuery>(), CancellationToken.None))
                         .ReturnsAsync(students);

            // Act
            var result = await _controller.GetAllStudents();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult; 
            Assert.Equal(students, okResult.Value); 
        }

        [Fact]
        public async Task AddStudent_ReturnsStatusCode201()
        {
            // Arrange
            var student = new Student { id="1",StudentName = "John",StudentAddress="Bangalore",StudentAge=21,StudentCourse="Ruby",StudentGender="Male" };

            // Act
            var result = await _controller.AddStudent(student);

            // Assert
            Assert.IsType<StatusCodeResult>(result); 
            var statusCodeResult = result as StatusCodeResult;
            Assert.Equal(201, statusCodeResult.StatusCode);
            _mockMediator.Verify(m => m.Send(It.IsAny<AddStudentCommand>(), CancellationToken.None), Times.Once);
        }

     
    }
}
