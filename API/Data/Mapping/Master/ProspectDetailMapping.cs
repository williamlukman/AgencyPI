using System.Data.Entity.ModelConfiguration;
using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    public class ProspectDetailMapping : EntityTypeConfiguration<ProspectDetail>
    {
        public ProspectDetailMapping()
        {
            HasKey(pd => pd.Id);
            HasRequired(pd => pd.Prospect)
                .WithMany(p => p.ProspectDetails)
                .HasForeignKey(pd => pd.ProspectId);
            Ignore(pd => pd.Errors);
        }
    }
}
