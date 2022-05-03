using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHttpClient.Models
{
    internal class Expense
    {
        public long ExpenseId { get; set; }
        public long ModelId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public string? Text { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public decimal amount { get; set; }
    }
}
