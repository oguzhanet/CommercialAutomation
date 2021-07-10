using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class Expense : IEntity
    {
        [Key]
        public int ExpenseId { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
