using MilestoneExam.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.WebApi.Tests
{
    public class BaseControllerTest
    {
        protected Mock<IServiceFactory> ServiceFactoryMock;

        protected Mock<IProductService> ProductServiceMock;

        protected Mock<ICustomerService> CustomerServiceMock;

        protected Mock<IPurchaseService> PurchaseServiceMock;

        public BaseControllerTest()
        {
            ServiceFactoryMock = new Mock<IServiceFactory>();

            ProductServiceMock = new Mock<IProductService>();

            CustomerServiceMock = new Mock<ICustomerService>();

            PurchaseServiceMock = new Mock<IPurchaseService>();

            ServiceFactoryMock.Setup(x => x.GetCustomerService()).Returns(CustomerServiceMock.Object);

            ServiceFactoryMock.Setup(x => x.GetProductService()).Returns(ProductServiceMock.Object);

            ServiceFactoryMock.Setup(x => x.GetPurchaseService()).Returns(PurchaseServiceMock.Object);
        }
    }
}
