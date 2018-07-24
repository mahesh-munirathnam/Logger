namespace Logger.DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonSession")]
    public partial class PersonSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SessionID { get; set; }

        public long PersonID { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(50)]
        public string AuthToken { get; set; }
    }
}
