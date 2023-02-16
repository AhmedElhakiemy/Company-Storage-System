namespace LinqEFProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ImportItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImportNum { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemCode { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpireDate { get; set; }

        public virtual ImportPermission ImportPermission { get; set; }

        public virtual Item Item { get; set; }
    }
}
