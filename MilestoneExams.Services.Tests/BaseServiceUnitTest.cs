using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilestoneExam.Common;
using MilestoneExam.Data.Models;
using MilestoneExam.Data.Repositories.Interfaces;
using Moq;

namespace MilestoneExam.Services.Tests
{
    public class BaseServiceUnitTest
    {
        protected Mock<IRepositoryFactory> RepositoryFactoryMock;

        protected Mock<IProductRepository> ProductRepositoryMock;

        protected Mock<ICustomerRepository> CustomerRepositoryMock;

        protected Mock<IGenericRepository<Purchase>> PurchaseRepositoryMock;

        public BaseServiceUnitTest()
        {
            RepositoryFactoryMock = new Mock<IRepositoryFactory>();
            ProductRepositoryMock = new Mock<IProductRepository>();
            CustomerRepositoryMock = new Mock<ICustomerRepository>();
            PurchaseRepositoryMock = new Mock<IGenericRepository<Purchase>>();

            RepositoryFactoryMock.Setup(x => x.GetCustomerRepository()).Returns(CustomerRepositoryMock.Object);
            RepositoryFactoryMock.Setup(x => x.GetProductRepository()).Returns(ProductRepositoryMock.Object);
            RepositoryFactoryMock.Setup(x => x.GetPurchaseRepository()).Returns(PurchaseRepositoryMock.Object);

            RepositoryFactoryMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);
        }
    }
}
