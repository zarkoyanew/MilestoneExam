using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Data.Models
{
    public class Purchase
    {
        public long CustomerId { get; set; }

        public long ProductId { get; set; }

        [Required]
        public decimal ProductQuantity { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
