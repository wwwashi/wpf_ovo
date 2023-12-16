namespace WpfOvo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            PatrolsComposition = new HashSet<PatrolsComposition>();
            SecurityObjects = new HashSet<SecurityObjects>();
            SecurityObjects1 = new HashSet<SecurityObjects>();
        }

        [Key]
        public int IDUser { get; set; }

        [Required]
        [StringLength(20)]
        public string Surname { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Midname { get; set; }

        [Required]
        [StringLength(18)]
        public string Phone { get; set; }

        public int RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public int? GenderID { get; set; }

        public virtual Gender Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatrolsComposition> PatrolsComposition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecurityObjects> SecurityObjects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecurityObjects> SecurityObjects1 { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
