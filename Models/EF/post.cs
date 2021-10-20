namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("post")]
    public partial class post
    {
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        public int category { get; set; }

        public bool? publish_state { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? published_at { get; set; }

        [Column(TypeName = "image")]
        public byte[] img { get; set; }

        public virtual category category1 { get; set; }
    }
}
