using MilestoneExam.Common.Exceptions;
using MilestoneExam.Data.Models;
using MilestoneExam.Data.Repositories.Interfaces;
using MilestoneExam.Services;
using MilestoneExam.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MilestoneExam.Services.Tests
{
    public class PurchaseServiceTests : BaseServiceUnitTest
    {
        private readonly IPurchaseService _service;

        public PurchaseServiceTests() : base()
        {
            _service = new PurchaseService(RepositoryFactoryMock.Object);
        }

        [Fact]
        public async Task AddOrUpdateAsync_PurchaseIsNew_AddAsyncIsCalled()
        {
            //Arrange
            var purchase = new Purchase
            {
                CustomerId = 1,
                ProductId = 1,
                ProductQuantity = 1
            };

            //Act
            await _service.AddAsync(purchase);

            //Assert
            PurchaseRepositoryMock.Verify(x => x.AddAsync(purchase), Times.Once);
            RepositoryFactoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_PurchaseNotFound_DeleteIsNotCalled()
        {
            //Arrange
            var customer = new Purchase { CustomerId = 1, ProductId = 1 };

            ProductRepositoryMock.Setup(x => x.FindAsync(It.IsAny<long>())).ReturnsAsync(default(Product));

            //Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.DeleteAsync(customer));
        }
    }
}
