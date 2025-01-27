﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Entities;

namespace TKMaster.ProjetoAulaAdilson.Core.Data
{
    public class MeuContextoBD : DbContext
    {
        #region Constructor

        public MeuContextoBD(DbContextOptions options) : base(options)
        {
        }

        #endregion

        #region DBSets

        public DbSet<Cliente> Clientes { get; set; }

        #endregion

        #region ModelBuilder e SaveChanges

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(255)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuContextoBD).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(false);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries()
                                  .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("Status").CurrentValue = true;
                    entry.Property("DataAlteracao").IsModified = false;
                    entry.Property("DataExclusao").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;

                    if ((bool)entry.Property("Status").CurrentValue)
                    {
                        entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                        entry.Property("DataExclusao").IsModified = false;
                    }
                    else
                    {
                        entry.Property("DataAlteracao").IsModified = false;
                        entry.Property("DataExclusao").CurrentValue = DateTime.Now;
                    }
                }
            }

            foreach (var entry in ChangeTracker.Entries()
                                 .Where(entry => entry.Entity.GetType().GetProperty("DataAlteracao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAlteracao").IsModified = false;
                    entry.Property("DataExclusao").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;

                    if ((bool)entry.Property("Status").CurrentValue)
                    {
                        entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                        entry.Property("DataExclusao").IsModified = false;
                    }
                    else
                    {
                        entry.Property("DataAlteracao").IsModified = false;
                        entry.Property("DataExclusao").CurrentValue = DateTime.Now;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}
