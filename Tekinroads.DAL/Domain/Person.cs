namespace Logger.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            PersonPermissions = new HashSet<PersonPermission>();
            Transactions = new HashSet<Transaction>();
            TransactionTypes = new HashSet<TransactionType>();
        }

        public long PersonId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        public bool Is_Active { get; set; }

        [Required]
        [StringLength(254)]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonPermission> PersonPermissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionType> TransactionTypes { get; set; }
    }
}
