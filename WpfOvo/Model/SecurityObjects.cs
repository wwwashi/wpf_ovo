namespace WpfOvo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SecurityObjects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SecurityObjects()
        {
            Acts = new HashSet<Acts>();
            SecurityContracts = new HashSet<SecurityContracts>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDObjects { get; set; }

        public int UserID { get; set; }

        [Required]
        public string Address { get; set; }

        [Column(TypeName = "image")]
        public byte[] PlanObject { get; set; }

        public int CountExit { get; set; }

        public int ClientPersonID { get; set; }

        public int AlarmsID { get; set; }

        public bool AlarmOperation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acts> Acts { get; set; }

        public virtual Alarms Alarms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecurityContracts> SecurityContracts { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
