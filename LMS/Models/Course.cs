namespace LMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }

        public DateTime? DateCreated { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateStarts { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateEnds { get; set; }

        public int? Active { get; set; }
    }
}
