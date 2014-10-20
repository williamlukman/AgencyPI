using System.Data.Entity.ModelConfiguration;
using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    public class ProspectMapping : EntityTypeConfiguration<Prospect>
    {
        public ProspectMapping()
        {
            HasKey(p => p.Id);
            HasRequired(p => p.Agent)
                .WithMany(a => a.Prospects)
                .HasForeignKey(p => p.AgentId);
            HasMany(p => p.ProspectDetails)
                .WithRequired(pd => pd.Prospect)
                .HasForeignKey(pd => pd.ProspectId);
            Ignore(wi => wi.Errors);
        }
    }
}
