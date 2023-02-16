namespace LinqEFProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            RequestPermissions = new HashSet<RequestPermission>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientId { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        [StringLength(50)]
        public string ClientMail { get; set; }

        [StringLength(50)]
        public string ClientFax { get; set; }

        [StringLength(50)]
        public string ClientMobile { get; set; }

        [StringLength(50)]
        public string ClientWebsite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestPermission> RequestPermissions { get; set; }
    }
}
