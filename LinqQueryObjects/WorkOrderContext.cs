using LinqQueryObjects.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueryObjects
{
    public class WorkOrderContext : DbContext
    {
        public WorkOrderContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<WorkOrderContext>(null);
            //Database.SetInitializer<WorkOrderContext>(CreateDatabaseIfNotExists<WorkOrderContext>) ;
        }
        

        public DbSet<Model.Workorder> Workorder { get; set; }
        public DbSet<Model.WorkorderAudit> WorkorderAudit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workorder>().ToTable("Workorder")
              .HasKey(table => new { table.Id, table.EnterpriseId, table.StatusId })
                .HasMany(table => table.WorkorderAudits);


            modelBuilder.Entity<WorkorderAudit>().ToTable("Workorder_Audit");
        }
    }


}
