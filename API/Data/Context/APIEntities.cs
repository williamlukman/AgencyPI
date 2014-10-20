using Core.DomainModel;
using Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Data.Migrations;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Context
{
    public class APIEntities : DbContext
    {
        public APIEntities() : base("API")
        {
            Database.SetInitializer<APIEntities>(new MigrateDatabaseToLatestVersion<APIEntities, Configuration>());
        }

        public void DeleteAllTables()
        {
            IList<String> tableNames = new List<String>();

            IList<String> userroleNames = new List<String>()
                                        { "UserMenu", "UserAccount", "UserAccess" };
            IList<String> masterNames = new List<String>()
                                        { "Agent", "Prospect", "ProspectAgentMutation",
                                          "ProspectDetail", "Company" };

            userroleNames.ToList().ForEach(x => tableNames.Add(x));
            masterNames.ToList().ForEach(x => tableNames.Add(x));

            foreach (var tableName in tableNames)
            {
                Database.ExecuteSqlCommand(string.Format("DELETE FROM {0}", tableName));
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AgentMapping());
            modelBuilder.Configurations.Add(new CompanyMapping());
            modelBuilder.Configurations.Add(new ProspectMapping());
            modelBuilder.Configurations.Add(new ProspectAgentMutationMapping());
            modelBuilder.Configurations.Add(new ProspectDetailMapping());
            modelBuilder.Configurations.Add(new UserAccountMapping());
            modelBuilder.Configurations.Add(new UserMenuMapping());
            modelBuilder.Configurations.Add(new UserAccessMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Prospect> Prospects { get; set; }
        public DbSet<ProspectAgentMutation> ProspectAgentMutations { get; set; }
        public DbSet<ProspectDetail> ProspectDetails { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserMenu> UserMenus { get; set; }
        public DbSet<UserAccess> UserAccesses { get; set; } 
    }
}