using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public partial class ProspectAgentMutation
    {
        public int Id { get; set; }

        public int ProspectId { get; set; }
        public int NewAgentId { get; set; }
        public int RecruitmentStatus { get; set; } // Join Field Work / Recruit
        public int RefereeAgentId { get; set; }
        public int NewDirectLeaderId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public bool IsConfirmed { get; set; }
        public Nullable<DateTime> ConfirmationDate { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public virtual Prospect Prospect { get; set; }
        public virtual Agent NewAgent { get; set; }
        public virtual Agent RefereeAgent { get; set; }
        public virtual Agent NewDirectLeader { get; set; }
    }
}
