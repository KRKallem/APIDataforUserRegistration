namespace APIDataforUserRegistration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("studentinfo")]
    public partial class studentinfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public studentinfo()
        {
            StudentDepartments = new HashSet<StudentDepartment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }

        [StringLength(100)]
        public string StudentName { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public int? DepartmentID { get; set; }

        [StringLength(100)]
        public string DepartmentName { get; set; }

        [StringLength(20)]
        public string gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentDepartment> StudentDepartments { get; set; }
    }
}
