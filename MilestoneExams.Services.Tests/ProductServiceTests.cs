using MilestoneExam.Common.Exceptions;
using MilestoneExam.Data.Models;
using MilestoneExam.Services;
using MilestoneExam.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MilestoneExam.Services.Tests
{
    public class ProductServiceTests : BaseServiceUnitTest
    {
        private readonly IProductService _service;

        public ProductServiceTests() : base()
        {
            _service = new ProductService(RepositoryFactoryMock.Object);
        }

        [Fact]
        public async Task AddOrUpdateAsync_ProductIsNew_AddAsyncIsCalled()
        {
            //Arrange
            var product = new Product
            {
                Id = 1,
                Name = "Test"
            };

            ProductRepositoryMock.Setup(x => x.FindAsync(It.IsAny<long>())).ReturnsAsync(default(Product));

            //Act
            await _service.AddOrUpdateAsync(product);

            //Assert
            ProductRepositoryMock.Verify(x => x.AddAsync(product), Times.Once);
            RepositoryFactoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task AddOrUpdateAsync_ProductExist_UpdateIsCalled()
        {
            //Arrange
            var dbProduct = new Product
            {
                Id = 1,
                Name = "Old Customer"
            };

            var product = new Product
            {
                Id = 1,
                Name = "New Customer"
            };

            ProductRepositoryMock.Setup(x => x.FindAsync(It.IsAny<long>())).ReturnsAsync(dbProduct);

            //Act
            await _service.AddOrUpdateAsync(product);

            //Assert
            ProductRepositoryMock.Verify(x => x.UpdateAsync(dbProduct, product), Times.Once);
            RepositoryFactoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ProductNotFound_DeleteIsNotCalled()
        {
            //Arrange
            var customer = new Product { Id = 1 };

            ProductRepositoryMock.Setup(x => x.FindAsync(It.IsAny<long>())).ReturnsAsync(default(Product));

            //Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.DeleteAsync(customer));
        }
    }
}
