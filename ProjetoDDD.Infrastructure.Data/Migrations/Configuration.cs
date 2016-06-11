namespace ProjetoDDD.Infrastructure.Data.Migrations
{
    using Initializer;
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<Context.ContextoBanco>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.ContextoBanco context)
        {
            if (context.PerfilUsuario.Where(x => x.NomPerfil == "Administrador Master").Count() == 0)
                UserDatabaseInitializer.GetPerfisUsuarios().ForEach(c => context.PerfilUsuario.Add(c));

            // Delete all stored procs, views
            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", ""), "Sql\\Seed"), "*.sql"))
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file), new object[0]);
            }

            // Add Stored Procedures
            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", ""), "Sql\\StoredProcs"), "*.sql"))
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file), new object[0]);
            }
        }
    }
}
