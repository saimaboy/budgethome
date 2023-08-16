namespace BudgetHomeDesign.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FoundationOnly")]
    public partial class FoundationOnly
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}
