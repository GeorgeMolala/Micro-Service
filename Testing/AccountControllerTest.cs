using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Micro_Service.Controllers;
using Micro_Service.Data;
using Moq;
using Micro_Service.Data.Repository;

namespace Testing
{
    public class AccountControllerTest
    {
        [Fact]
        public void Index_ReturnsARedirectToActionResult()
        {
            var unit = new Mock<MicroUnitOfWork>();
            var controller = new AccountController(unit.Object);
        }
    }
}
