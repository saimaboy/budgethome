using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetHomeDesign.Models
{
    public partial class CategorizedPlanGroup
    {
        public string StepName { get; set; }
        public List<Plan> Plans { get; set; }
    }

}