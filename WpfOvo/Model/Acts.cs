namespace WpfOvo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDActs { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        [Required]
        public string ReasonForDeparture { get; set; }

        [Required]
        public string ResultsInspection { get; set; }

        public bool AlarmOperation { get; set; }

        public int PatrolsID { get; set; }

        public int ObjectID { get; set; }

        public virtual Patrols Patrols { get; set; }

        public virtual SecurityObjects SecurityObjects { get; set; }
    }
}
