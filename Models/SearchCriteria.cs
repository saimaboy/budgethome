using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BudgetHomeDesign.Models
{
    public class SearchCriteria
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int People { get; set; }
        public decimal Size { get; set; }
        public int? Steps { get; set; }
        public int? Floors { get; set; }
    }
}