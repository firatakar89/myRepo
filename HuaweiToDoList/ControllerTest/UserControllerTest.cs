using System;
using Controller.Controllers;
using Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllerTest
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Login()
        {
            UserController uController = new UserController();
            User u = new User("Test","1234");
            u = uController.Login(u);
            Assert.IsNotNull(u.id);
        }
    }
}
