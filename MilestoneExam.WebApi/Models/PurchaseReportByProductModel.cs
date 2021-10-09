using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneExam.WebApi.Models
{
    public class PurchaseReportByProductModel
    {
        public List<PurchaseModel> Purchases { get; set; }

        public decimal TotalPaidPrice { get; set; }
    }
}
