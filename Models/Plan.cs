namespace BudgetHomeDesign.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plan")]
    public partial class Plan
    {
        [StringLength(50)]
        public string Id { get; set; }

        public decimal? Price { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal? Size { get; set; }

        public int? Steps { get; set; }

        public int? People { get; set; }

        public int? Floors { get; set; }

        public string PictureUrl { get; set; }
    }
}
