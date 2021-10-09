using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneExam.WebApi.Models
{
    public class PurchaseModel
    {
        public long CustomerId { get; set; }

        public long ProductId { get; set; }

        public decimal ProductQuantity { get; set; }

    }
}
