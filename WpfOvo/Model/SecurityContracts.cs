namespace WpfOvo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SecurityContracts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDSecurityContracts { get; set; }

        public int ObjectsID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfConclusion { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateEnd { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public virtual SecurityObjects SecurityObjects { get; set; }
    }
}
