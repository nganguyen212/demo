namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string first_name { get; set; }

        [Required]
        [StringLength(128)]
        public string last_name { get; set; }

        [Required]
        [StringLength(128)]
        public string email { get; set; }

        [Required]
        [StringLength(128)]
        public string user_name { get; set; }

        [Required]
        [StringLength(128)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string role { get; set; }
    }
}
