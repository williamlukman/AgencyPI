using System.Data.Entity.ModelConfiguration;
using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    public class ProspectAgentMutationMapping : EntityTypeConfiguration<ProspectAgentMutation>
    {
        public ProspectAgentMutationMapping()
        {
            HasKey(pam => pam.Id);
            HasRequired(pam => pam.Prospect)
                .WithMany(p => p.ProspectAgentMutations)
                .HasForeignKey(pam => pam.ProspectId);
            HasRequired(pam => pam.NewAgent)
                .WithMany()
                .HasForeignKey(pam => pam.NewAgentId)
                .WillCascadeOnDelete(false);
            HasRequired(pam => pam.RefereeAgent)
                .WithMany()
                .HasForeignKey(pam => pam.RefereeAgentId)
                .WillCascadeOnDelete(false);
            HasRequired(pam => pam.NewDirectLeader)
                .WithMany()
                .HasForeignKey(pam => pam.NewDirectLeaderId)
                .WillCascadeOnDelete(false);
            Ignore(pam => pam.Errors);
        }
    }
}
