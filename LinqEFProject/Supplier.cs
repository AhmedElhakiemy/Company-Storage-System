namespace LinqEFProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            ImportPermissions = new HashSet<ImportPermission>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplierId { get; set; }

        [StringLength(50)]
        public string SupplierName { get; set; }

        [StringLength(50)]
        public string SupplierMail { get; set; }

        [StringLength(50)]
        public string SupplierFax { get; set; }

        [StringLength(50)]
        public string SupplierMoblie { get; set; }

        [StringLength(50)]
        public string SupplierWebsite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportPermission> ImportPermissions { get; set; }
    }
}
