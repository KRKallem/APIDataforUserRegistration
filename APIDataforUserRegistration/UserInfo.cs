namespace APIDataforUserRegistration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Skillset { get; set; }

        [StringLength(100)]
        public string Hobby { get; set; }
    }
}
