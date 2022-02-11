using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_Tutorial.Models {

    public class Order {

        public int Id { get; set; } // primary key
        [Required] // this attribute does not allow null
        [StringLength(80)] // this attribute determines the string length
        public string Description { get; set; }
        [Column(TypeName = "decimal(11,2)")] // this attribute determines the decimal length
        public decimal Total { get; set; }

        public int CustomerId { get; set; } // foreign key
        public virtual Customer Customer { get; set; } // virtual means this property is in this class but not in the database

    }
}
