using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class ToDoList : IEntity
    {
        [Key]
        public int ToDoListId { get; set; }
        [StringLength(200)]
        public string ToDoListHeading { get; set; }
        public DateTime ToDoListDate { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
