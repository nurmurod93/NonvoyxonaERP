using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Maxsulot> Maxsulotlar { get; set; }
        public DbSet<Xomashyo> Xomashyolar { get; set; }
        public DbSet<Retsept> Retseptlar { get; set; }
        public DbSet<Xodim> Xodimlar { get; set; }
        public DbSet<Davomat> Davomatlar { get; set; }
        public DbSet<Maosh> Maoshlar { get; set; }
        public DbSet<IshAkt> IshAktlar { get; set; }
        public DbSet<IshAktQator> IshAktQatorlar { get; set; }
        public DbSet<Tochka> Tochkalar { get; set; }
        public DbSet<Transfer> Transferlar { get; set; }
        public DbSet<TransferQator> TransferQatorlar { get; set; }
        public DbSet<Savdo> Savdolar { get; set; }
        public DbSet<SavdoQator> SavdoQatorlar { get; set; }
        public DbSet<Kassa> Kassalar { get; set; }
        public DbSet<Xarajat> Xarajatlar { get; set; }
        public DbSet<Taminotchi> Taminotchilar { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Maxsulot
                modelBuilder.Entity<Maxsulot>()
                    .Property(x => x.Narxi).HasPrecision(18, 2);

                // Xomashyo
                modelBuilder.Entity<Xomashyo>()
                    .Property(x => x.Miqdori).HasPrecision(18, 3);
                modelBuilder.Entity<Xomashyo>()
                    .Property(x => x.Narxi).HasPrecision(18, 2);
                modelBuilder.Entity<Xomashyo>()
                    .Property(x => x.MinDaraja).HasPrecision(18, 3);

                // Retsept
                modelBuilder.Entity<Retsept>()
                    .Property(x => x.Miqdori).HasPrecision(18, 4);

                // Savdo
                modelBuilder.Entity<Savdo>()
                    .Property(x => x.JamiSumma).HasPrecision(18, 2);

                // SavdoQator
                modelBuilder.Entity<SavdoQator>()
                    .Property(x => x.Narx).HasPrecision(18, 2);

                // Kassa
                modelBuilder.Entity<Kassa>()
                    .Property(x => x.Qoldiq).HasPrecision(18, 2);

                // Maosh
                modelBuilder.Entity<Maosh>()
                    .Property(x => x.HisoblanganMaosh).HasPrecision(18, 2);
                modelBuilder.Entity<Maosh>()
                    .Property(x => x.Avans).HasPrecision(18, 2);
                modelBuilder.Entity<Maosh>()
                    .Property(x => x.Shtraf).HasPrecision(18, 2);
                modelBuilder.Entity<Maosh>()
                    .Property(x => x.Mukofot).HasPrecision(18, 2);
                modelBuilder.Entity<Maosh>()
                    .Property(x => x.Tolangan).HasPrecision(18, 2);

                // Xodim
                modelBuilder.Entity<Xodim>()
                    .Property(x => x.AsosiyMaoshi).HasPrecision(18, 2);
                modelBuilder.Entity<Xodim>()
                    .Property(x => x.IshbayNarxi).HasPrecision(18, 2);

                // Xarajat
                modelBuilder.Entity<Xarajat>()
                    .Property(x => x.Summa).HasPrecision(18, 2);

                // Taminotchi
                modelBuilder.Entity<Taminotchi>()
                    .Property(x => x.Qarz).HasPrecision(18, 2);
        }
    }
}
