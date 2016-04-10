using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerApp.Controllers;
namespace CustomerApp.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTest
    {
        [TestMethod]
        public void Get()
        {
            CustomersController controller = new CustomersController();
            var result = controller.Get();   
            Assert.IsNotNull(result);          
         }
    }
}
