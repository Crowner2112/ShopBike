namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Address { get; set; }

        public int Total { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int Status { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
    }
}
