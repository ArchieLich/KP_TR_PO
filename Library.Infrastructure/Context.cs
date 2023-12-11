using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Library.Infrastructure
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<RoleEntity> client { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<UserRoleEntity> role { get; set; }
        public virtual DbSet<UserEntity> user { get; set; }
        public virtual DbSet<PublicationEntity> uslugi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<UserRoleEntity>()
                .HasMany(e => e.user)
                .WithRequired(e => e.role)
                .HasForeignKey(e => e.idrole)
                .WillCascadeOnDelete(false);

        }
    }
}
