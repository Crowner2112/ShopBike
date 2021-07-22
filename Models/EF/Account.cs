namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string FullName { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(30)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int? Role { get; set; }
    }
}
