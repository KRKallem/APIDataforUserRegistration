namespace APIDataforUserRegistration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentDepartment")]
    public partial class StudentDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentID { get; set; }

        [StringLength(100)]
        public string DepartmentName { get; set; }

        public int StudentID { get; set; }

        public virtual studentinfo studentinfo { get; set; }
    }
}
