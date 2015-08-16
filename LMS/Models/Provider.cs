namespace LMS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Provider : DbContext
    {
        public Provider()
            : base("name=Provider")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
