using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SystemClub.Models;
using SystemClub.Contex;

namespace SystemClub.Migrations
{
    public class Context : DbContext //ContextoCK
    {
        private static bool b_SQLServer = false;
        public static string sServidor;

        public Context()
            : base("conexao")
        {
            Database.SetInitializer(new MigrationsCustom<Context, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        ////Utilizando esta aqui
        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}


        public static string GetConnection()
        {
            var connectionString = ((b_SQLServer) ? "SQLServer" : "MySQL");
            return connectionString.ToString();
        }

        //public DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Agregado> Agregados { get; set; }

    }
}