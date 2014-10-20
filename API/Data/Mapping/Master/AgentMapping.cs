using System.Data.Entity.ModelConfiguration;
using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    public class AgentMapping : EntityTypeConfiguration<Agent>
    {
        public AgentMapping()
        {
            HasKey(a => a.Id);
            HasOptional(a => a.DirectLeader)
                .WithMany()
                .HasForeignKey(a => a.DirectLeaderId)
                .WillCascadeOnDelete(false);
            HasMany(a => a.Prospects)
                .WithRequired(p => p.Agent)
                .HasForeignKey(p => p.AgentId);
            Ignore(a => a.Errors);
        }
    }
}
