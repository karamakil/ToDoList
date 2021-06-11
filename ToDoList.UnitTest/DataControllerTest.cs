using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL.DAL;
using ToDoList.Controllers;
using Xunit;

namespace ToDoList.UnitTest
{
    public class DataControllerTest
    {
        DataController _controller;

        #region ctor

        public DataControllerTest()
        {
            _controller = new DataController();
        }

        #endregion

        [Fact]
        public void GetToDoList_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetToDoList() as ObjectResult;
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            int testId = 4;
            // Act
            var okResult = _controller.GetById(testId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            int testId = 4;
            // Act
            var okResult = _controller.GetById(testId).Result as OkObjectResult;
            // Assert
            Assert.IsType<ToDo>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as ToDo).Id);
        }

        [Fact]
        public void SaveToDo_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new ToDo()
            {
                Title = "UnitTestingNewToDo",
            };
            _controller.ModelState.AddModelError("Id", "Required");
            // Act
            var badResponse = _controller.SaveToDo(nameMissingItem);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void SaveToDo_ValidObjectPassed_ReturnsOkResult()
        {
            // Arrange
            ToDo toDo = new ToDo()
            {
                Id = 0,
                Title = "HelloUnitTesting"
            };
            // Act
            var createdResponse = _controller.SaveToDo(toDo);
            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkResult>(createdResponse);
        }

        [Fact]
        public void DeleteToDo_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            int existingId = 5;
            // Act
            var okResponse = _controller.DeleteToDo(existingId);
            // Assert
            Assert.IsType<OkResult>(okResponse);
        }


    }
}
