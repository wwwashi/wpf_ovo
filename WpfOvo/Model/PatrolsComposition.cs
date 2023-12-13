namespace WpfOvo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PatrolsComposition")]
    public partial class PatrolsComposition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDComposition { get; set; }

        public int UserID { get; set; }

        public int IDPatrols { get; set; }

        public virtual Patrols Patrols { get; set; }

        public virtual Users Users { get; set; }
    }
}
