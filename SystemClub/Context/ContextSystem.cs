using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SystemClub.Models;
using SystemClub.Contex;
using SystemClub.Migrations;

namespace SystemClub.Context
{
    public class ContextSystem : DbContext
    {
        public ContextSystem()
            : base("conexao")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            Database.SetInitializer(new MigrationsCustom<ContextSystem, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove();
        }

        ////Utilizando esta aqui
        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}


        //public static string GetConnection()
        //{
        //    var connectionString = ((b_SQLServer) ? "SQLServer" : "MySQL");
        //    return connectionString.ToString();
        //}

        //public DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Agregado> Agregados { get; set; }

        public class ContextInitializer : DropCreateDatabaseIfModelChanges<ContextSystem>
        {

        }
       
    
    }
}