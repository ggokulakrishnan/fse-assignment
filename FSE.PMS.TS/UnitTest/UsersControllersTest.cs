﻿using System.Web.Http.Results;
using NUnit.Framework;
using FSE.PMS.IL;
using FSE.PMS.Controllers;
using System.Collections.ObjectModel;
using ProjectMangerModel = FSE.PMS.Models;

namespace FSE.PMS.Tests.UnitTest
{
    [TestFixture]
    public class UsersControllersTest
    {
        private IUserBL userBL;
        private UsersController userController;

        [SetUp]
        public void TestSetUp()
        {
            userBL = new MockUserBL();
            userController = new UsersController(userBL);
        }

        [TearDown]
        public void TestTearDown()
        {
            userBL = null;
            userController = null;
        }

        [Test]
        public void GetUsersTest()
        {
            var response = userController.GetUsers();
            var responseResult = response as OkNegotiatedContentResult<Collection<ProjectMangerModel.Users>>;
            Assert.IsNotNull(responseResult);
            Assert.IsNotNull(responseResult.Content);
            foreach (var user in responseResult.Content)
            {
                Assert.IsNotNull(user.UserID);
                Assert.IsNotNull(user.FirstName);
                Assert.IsNotNull(user.LastName);
                Assert.IsNotNull(user.EmployeeID);
            }
        }

        [Test]
        public void AddUserTest_Success()
        {
            // Arrange
            ProjectMangerModel.Users model = new ProjectMangerModel.Users
            {
                UserID = 4,
                FirstName = "Meena",
                LastName = "M",
                EmployeeID = "433466"
            };

            // Act
            var response = userController.AddUser(model);

            // Assert
            Assert.IsTrue(response is OkResult);
        }

        [Test]
        public void AddUserTest_Error()
        {
            // Arrange
            var userController = new UsersController(null);

            ProjectMangerModel.Users model = new ProjectMangerModel.Users
            {
                UserID = 4,
                FirstName = "Meena",
                LastName = "M",
                EmployeeID = "433466"
            };

            // Act
            var response = userController.AddUser(model);

            // Assert
            Assert.IsTrue(response is InternalServerErrorResult);
        }

        [Test]
        public void UpdateUserTest_Success()
        {
            // Arrange
            ProjectMangerModel.Users model = new ProjectMangerModel.Users
            {
                UserID = 1,
                FirstName = "Sathya",
                LastName = "Natarajan",
                EmployeeID = "433465"
            };

            // Act
            var response = userController.UpdateUser(model);

            // Assert
            Assert.IsTrue(response is OkResult);
        }

        [Test]
        public void UpdateUserTest_Error()
        {
            // Arrange
            var userController = new UsersController(null);

            ProjectMangerModel.Users model = new ProjectMangerModel.Users
            {
                UserID = 1,
                FirstName = "Sathya",
                LastName = "Natarajan",
                EmployeeID = "433465"
            };

            // Act
            var response = userController.UpdateUser(model);

            // Assert
            Assert.IsTrue(response is InternalServerErrorResult);
        }

        [Test]
        public void DeleteUserTest_Success()
        {
            // Arrange
            ProjectMangerModel.Users model = new ProjectMangerModel.Users
            {
                UserID = 1,
                FirstName = "Sathya",
                LastName = "Natarajan",
                EmployeeID = "433461"
            };

            // Act
            var response = userController.DeleteUser(model);

            // Assert
            Assert.IsTrue(response is OkResult);
        }

        [Test]
        public void DeleteUserTest_Error()
        {
            // Arrange
            var userController = new UsersController(null);

            ProjectMangerModel.Users model = new ProjectMangerModel.Users
            {
                UserID = 1,
                FirstName = "Sathya",
                LastName = "Natarajan",
                EmployeeID = "433461"
            };

            // Act
            var response = userController.DeleteUser(model);

            // Assert
            Assert.IsTrue(response is InternalServerErrorResult);
        }
    }
}
