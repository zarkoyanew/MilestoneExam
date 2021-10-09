using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneExam.WebApi.Models
{
    public class PurchaseReportByCustomerModel
    {
        public List<PurchaseModel> Purchases { get; set; }

        public int UniqueProductsCount { get; set; }
    }
}
