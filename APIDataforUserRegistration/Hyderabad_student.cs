namespace APIDataforUserRegistration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hyderabad student")]
    public partial class Hyderabad_student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int studentid { get; set; }

        [StringLength(100)]
        public string studentname { get; set; }
    }
}
