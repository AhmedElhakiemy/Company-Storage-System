namespace LinqEFProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ItemUnit
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Unit { get; set; }

        public virtual Item Item { get; set; }
    }
}
