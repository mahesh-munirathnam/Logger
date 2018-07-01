namespace Logger.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinancialTransaction")]
    public partial class FinancialTransaction
    {
        public long ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public long CreatedBy { get; set; }

        public long TransactionTypeID { get; set; }

        public virtual Person Person { get; set; }

        public virtual TransactionType TransactionType { get; set; }
    }
}
