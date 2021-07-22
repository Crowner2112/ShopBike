namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Link { get; set; }

        public bool? MainPic { get; set; }

        public virtual Product Product { get; set; }
    }
}
