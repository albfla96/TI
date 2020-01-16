using MySql.Data.Entity;
using TI.Models;
using System.Data.Entity;

namespace TI.DB
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataContext : DbContext
    {
        public DbSet<Utilizator> Angajati { get; set; }
        public DbSet<Procent> Impozite { get; set; }

        public DataContext() : base("DefaultConnection")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Utilizator>().ToTable("utilizator");
            modelBuilder.Entity<Utilizator>().Property(t => t.NrCrt).HasColumnName("NR_CRT");
            modelBuilder.Entity<Utilizator>().Property(t => t.Nume).HasColumnName("NUME");
            modelBuilder.Entity<Utilizator>().Property(t => t.Prenume).HasColumnName("PRENUME");
            modelBuilder.Entity<Utilizator>().Property(t => t.Functie).HasColumnName("FUNCTIE");
            modelBuilder.Entity<Utilizator>().Property(t => t.SalarBaza).HasColumnName("SALAR_BAZA");
            modelBuilder.Entity<Utilizator>().Property(t => t.Spor).HasColumnName("SPOR_%");
            modelBuilder.Entity<Utilizator>().Property(t => t.PremiiBrute).HasColumnName("PREMII_BRUTE");
            modelBuilder.Entity<Utilizator>().Property(t => t.TotalBrut).HasColumnName("TOTAL_BRUT");
            modelBuilder.Entity<Utilizator>().Property(t => t.BrutImpozitabil).HasColumnName("BRUT_IMPOZITABIL");
            modelBuilder.Entity<Utilizator>().Property(t => t.Virat).HasColumnName("VIRAT");
            modelBuilder.Entity<Utilizator>().Property(t => t.Impozit).HasColumnName("IMPOZIT");
            modelBuilder.Entity<Utilizator>().Property(t => t.CAS).HasColumnName("CAS");
            modelBuilder.Entity<Utilizator>().Property(t => t.CASS).HasColumnName("CASS");
            modelBuilder.Entity<Utilizator>().Property(t => t.Retineri).HasColumnName("RETINERI");

            modelBuilder.Entity<Procent>().Property(t => t.ID).HasColumnName("ID");
            modelBuilder.Entity<Procent>().Property(t => t.NumeVariabila).HasColumnName("NUME_VARIABILA");
            modelBuilder.Entity<Procent>().Property(t => t.ProcentProp).HasColumnName("PROCENT");
        }
    }
}