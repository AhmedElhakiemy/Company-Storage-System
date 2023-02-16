namespace LinqEFProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestPermission")]
    public partial class RequestPermission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestPermission()
        {
            RequestItems = new HashSet<RequestItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestNum { get; set; }

        public int? StoreId { get; set; }

        public int? ClientId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RequestDate { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestItem> RequestItems { get; set; }

        public virtual Store Store { get; set; }
    }
}
