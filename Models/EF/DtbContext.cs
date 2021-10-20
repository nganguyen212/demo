namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DtbContext : DbContext
    {
        public DtbContext()
            : base("name=DtbContext")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.posts)
                .WithRequired(e => e.category1)
                .HasForeignKey(e => e.category)
                .WillCascadeOnDelete(false);
        }
    }
}
