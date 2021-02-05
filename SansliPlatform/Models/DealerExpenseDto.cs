using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SansliPlatform.Models
{
    public class DealerExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExpenseDate { get; set; }
        public string TotalPrice { get; set; }
        public string DealerPrice { get; set; }
    }
}
