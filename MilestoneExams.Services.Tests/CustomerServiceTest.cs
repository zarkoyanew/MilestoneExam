using MilestoneExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilestoneExam.Common;
using MilestoneExam.Common.Exceptions;
using MilestoneExam.Data.Models;
using MilestoneExam.Services;
using Xunit;
using Moq;
using System.Linq.Expressions;

namespace MilestoneExam.Services.Tests
{
    public class CustomerServiceTest : BaseServiceUnitTest
    {
        private readonly ICustomerService _service;

        public CustomerServiceTest() : base()
        {
            _service = new CustomerService(RepositoryFactoryMock.Object);
        }

        [Fact]
        public async Task AddOrUpdateAsync_CustomerIsNew_AddAsyncIsCalled()
        {
            //Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "Test"
            };

            CustomerRepositoryMock.Setup(x => x.FindAsync(It.IsAny<long>())).ReturnsAsync(default(Customer));

            //Act
            await _service.AddOrUpdateAsync(customer);

            //Assert
            CustomerRepositoryMock.Verify(x => x.AddAsync(customer), Times.Once);
            RepositoryFactoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task AddOrUpdateAsync_CustomerExist_UpdateIsCalled()
        {
            //Arrange
            var dbCustomer = new Customer
            {
                Id = 1,
                Name = "Old Customer"
            };

            var customer = new Customer
            {
                Id = 1,
                Name = "New Customer"
            };

            CustomerRepositoryMock.Setup(x => x.FindAsync(It.IsAny<long>())).ReturnsAsync(dbCustomer);

            //Act
            await _service.AddOrUpdateAsync(customer);

            //Assert
            CustomerRepositoryMock.Verify(x => x.UpdateAsync(dbCustomer, customer), Times.Once);
            RepositoryFactoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_CustomerNotFound_DeleteIsNotCalled()
        {
            //Arrange
            var customer = new Customer { Id = 1 };

            CustomerRepositoryMock.Setup(x => x.FindAsync(It.IsAny<long>())).ReturnsAsync(default(Customer));

            //Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.DeleteAsync(customer));
        }
    }
}
