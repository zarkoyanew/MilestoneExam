using MilestoneExam.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.WebApi.Tests
{
    public class CustomerControllerTests : BaseControllerTest
    {
        private readonly CustomerController _controller;

        public CustomerControllerTests()
        {
            _controller = new CustomerController(ServiceFactoryMock.Object);
        }
    }
}
