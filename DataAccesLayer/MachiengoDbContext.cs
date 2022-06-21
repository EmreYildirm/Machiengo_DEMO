using Machinego_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Machinego_Demo.DataAccesLayer
{
    public class MachiengoDbContext : DbContext
    {
        public MachiengoDbContext(DbContextOptions<MachiengoDbContext> options) : base(options)
        {

        }
        public DbSet<Machine> Machine { get; set; }
        public DbSet<MachineType> MachineType { get; set; }
        public DbSet<MachineCategory> MachineCategory { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Attachment> Attachment { get; set; }

        public DbSet<MachineAttachments> MachineAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MachineAttachments>().HasKey(ma => new { ma.MachineId, ma.AttachmentId });


            modelBuilder.Entity<MachineAttachments>()
            .HasOne<Machine>(ma => ma.Machine)
            .WithMany(m => m.MachineAttachments)
            .HasForeignKey(ma => ma.MachineId);


            modelBuilder.Entity<MachineAttachments>()
                .HasOne<Attachment>(ma => ma.Attachment)
                .WithMany(m => m.MachineAttachments)
                .HasForeignKey(ma => ma.AttachmentId);

            modelBuilder.Entity<MachineCategory>()
             .HasData(
              new Attachment { Id = 1, Name = "Hafriyat Grubu   " },
              new Attachment { Id = 2, Name = "Asfalt ve Yol Makinalari" });

            modelBuilder.Entity<MachineType>()
             .HasData(
              new MachineType { Id = 1, Name = "Ekskavatörler", MachineCategory = 1 },
              new MachineType { Id = 2, Name = "Bobcat ", MachineCategory = 1 },
              new MachineType { Id = 3, Name = "El Silindiri", MachineCategory = 2 },
              new MachineType { Id = 4, Name = "Mobil Taş Kırma Makinası", MachineCategory = 2 });

            modelBuilder.Entity<Brand>()
             .HasData(
              new Brand { Id = 1, Name = "Mercedes", MachineCategory = 1 },
              new Brand { Id = 2, Name = "CAT", MachineCategory = 2 },
              new Brand { Id = 3, Name = "BMW", MachineCategory = 1 },
              new Brand { Id = 4, Name = "Renault", MachineCategory = 2 });



            modelBuilder.Entity<Attachment>()
             .HasData(
              new Attachment { Id = 1, Name = "Grapple", MachineType = 1 },
              new Attachment { Id = 2, Name = "Elek Ataşmanı", MachineType = 1 },
              new Attachment { Id = 3, Name = "Diğer", MachineType = 3 },
              new Attachment { Id = 4, Name = "Açılı Süpürge", MachineType = 2 },
              new Attachment { Id = 5, Name = "Beton Kırıcı", MachineType = 2 });

            modelBuilder.Entity<User>()
             .HasData(
              new User { Id = 1, Name = "Admin", Password = "12345", Email = "admin@mail.com" });
        }
    }
}
