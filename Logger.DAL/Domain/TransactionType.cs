namespace Logger.DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mst.TransactionType")]
    public partial class TransactionType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransactionType()
        {
            FinancialTransactions = new HashSet<FinancialTransaction>();
        }

        public long ID { get; set; }

        [Column("TransactionType")]
        [Required]
        [StringLength(20)]
        public string TransactionType1 { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public long CreatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinancialTransaction> FinancialTransactions { get; set; }

        public virtual Person Person { get; set; }
    }
}
