namespace WpfOvo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users : IValidatableObject
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

        [property: Required]
        [property: StringLength(20)]
        public string Surname { get; set; }

        [property: Required]
        [property: StringLength(15)]
        public string Name { get; set; }

        [property: StringLength(20)]
        public string Midname { get; set; }

        [property: Required]
        [property: StringLength(11)]
        public string Phone { get; set; }

        public int RoleID { get; set; }

        [property: Required]
        [property: StringLength(50)]
        public string Login { get; set; }

        [property: Required]
        [property: StringLength(100)]
        public string Password { get; set; }

        public int? GenderID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public virtual Gender Gender { get; set; }

        [property: Required]
        [property: StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatrolsComposition> PatrolsComposition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecurityObjects> SecurityObjects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecurityObjects> SecurityObjects1 { get; set; }

        public virtual UserRole UserRole { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Surname) || !(Surname.Length >= 3 && Surname.Length <= 20))
                errors.Add(new ValidationResult("Фамилия должна быть от 3 до 20 символов."));

            if (string.IsNullOrEmpty(Name) || !(Name.Length >= 3 && Name.Length <= 15))
                errors.Add(new ValidationResult("Имя должно быть от 3 до 15 символов."));

            if (string.IsNullOrEmpty(Phone) || Phone.Length != 11)
                errors.Add(new ValidationResult("Телефон должен состоять из 11 символов"));
            return errors;
        }
    }
}
