namespace Logger.DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Workout")]
    public partial class Workout
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Exercise { get; set; }

        public long Reps { get; set; }

        public long Sets { get; set; }

        [StringLength(50)]
        public string Weight { get; set; }

        public long CreatedBy { get; set; }

        [StringLength(50)]
        public string Comments { get; set; }

        public virtual Person Person { get; set; }
    }
}
