namespace LinqEFProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImportPermission")]
    public partial class ImportPermission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImportPermission()
        {
            ImportItems = new HashSet<ImportItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImportNum { get; set; }

        public int? StoreId { get; set; }

        public int? SupplierId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ImportDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportItem> ImportItems { get; set; }

        public virtual Store Store { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
