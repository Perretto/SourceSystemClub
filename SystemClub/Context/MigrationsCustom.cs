using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Diagnostics.Contracts;

namespace SystemClub.Contex
{
    public class MigrationsCustom<TContext, TConfiguration> : CreateDatabaseIfNotExists<TContext>, IDatabaseInitializer<TContext>
        where TContext : DbContext
        where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly DbMigrationsConfiguration _configuration;
        public MigrationsCustom()
        {
            _configuration = new TConfiguration();
        }

        public MigrationsCustom(string connection)
        {
            Contract.Requires(!string.IsNullOrEmpty(connection), "connection");

            _configuration = new TConfiguration
            {
                TargetDatabase = new DbConnectionInfo(connection)
            };
        }

        void IDatabaseInitializer<TContext>.InitializeDatabase(TContext context)
        {
            Contract.Requires(context != null, "context");
            try
            {
                var migrator = new DbMigrator(_configuration);
                migrator.Update();

                // move on with the 'CreateDatabaseIfNotExists' for the 'Seed'
                base.InitializeDatabase(context);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void Seed(TContext context)
        {

        }
    }
}
