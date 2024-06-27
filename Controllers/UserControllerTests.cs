using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Web.Mvc;
using System.Linq;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Index_ReturnsViewWithUsers()
        {
            // Arrange
            UserController controller = new UserController();
            UserController.userlist.Add(new User { Id = 1, Name = "Test User", Email = "test@example.com" });

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = result.Model as System.Collections.Generic.List<User>;
            Assert.AreEqual(1, model.Count);
            // Cleanup
            UserController.userlist.Clear();
        }

        [TestMethod]
        public void Details_ReturnsUser()
        {
            // Arrange
            UserController controller = new UserController();
            UserController.userlist.Add(new User { Id = 1, Name = "Test User", Email = "test@example.com" });

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var user = result.Model as User;
            Assert.AreEqual("Test User", user.Name);
            // Cleanup
            UserController.userlist.Clear();
        }

        [TestMethod]
        public void Create_AddsUser_RedirectsToIndex()
        {
            // Arrange
            UserController controller = new UserController();
            User newUser = new User { Id = 1, Name = "New User", Email = "new@example.com" };

            // Act
            var result = controller.Create(newUser) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(1, UserController.userlist.Count);
            // Cleanup
            UserController.userlist.Clear();
        }

        // Additional tests for Edit, Delete etc. can be added here following the same pattern.
    }
}
