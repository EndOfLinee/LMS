namespace LMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string Title { get; set; }

        public string Content { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? Deleted { get; set; }
    }
}
