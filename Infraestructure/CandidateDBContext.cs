using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;

namespace Data
{
    public class CandidateDbContext: DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source= localhost\sqlexpress; 
        //            Initial Catalog=Candidate; 
        //            Integrated Security = True; Trust Server Certificate=true");
        //}


        public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.InsertDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasKey(m => m.Id);
            modelBuilder.Entity<Candidate>().HasAlternateKey(m => m.Email);

            modelBuilder.Entity<Candidate>()             
              .HasMany(m => m.CandidateExperiences)
              .WithOne(m => m.Candidate)
              .HasForeignKey(m => m.IdCandidate)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CandidateExperience>()
                .HasKey(m => m.Id);

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetIsUnicode(false);
            }

            modelBuilder.Entity<Candidate>().Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Entity<Candidate>().Property(p => p.Surname).HasMaxLength(150);
            modelBuilder.Entity<Candidate>().Property(p => p.Email).HasMaxLength(250);
            modelBuilder.Entity<Candidate>().Property(p => p.BirthDate).HasColumnType("datetime");
            modelBuilder.Entity<Candidate>().Property(p => p.Id).HasColumnName("IdCandidate");

            modelBuilder.Entity<CandidateExperience>().Property(p => p.Company).HasMaxLength(100);
            modelBuilder.Entity<CandidateExperience>().Property(p => p.Job).HasMaxLength(100);
            modelBuilder.Entity<CandidateExperience>().Property(p => p.Description).HasMaxLength(4000);
            modelBuilder.Entity<CandidateExperience>().Property(p => p.Salary).HasColumnType("numeric(8,2)");
            modelBuilder.Entity<CandidateExperience>().Property(p => p.BeginDate).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<CandidateExperience>().Property(p => p.EndDate).HasColumnType("datetime");
            modelBuilder.Entity<CandidateExperience>().Property(p => p.Id).HasColumnName("IdCandidateExperience");
        }

        public  DbSet<Candidate> Candidates { get; set; }
        public  DbSet<CandidateExperience> CandidateExperiences { get; set; }
    }
}