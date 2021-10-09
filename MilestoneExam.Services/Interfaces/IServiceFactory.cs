using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Services.Interfaces
{
    public interface IServiceFactory
    {
        IProductService GetProductService();

        ICustomerService GetCustomerService();

        IPurchaseService GetPurchaseService();
    }
}
