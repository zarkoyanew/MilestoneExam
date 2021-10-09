using MilestoneExam.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MilestoneExam.Data.Models
{
    public class Customer : ISingleKeyModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
