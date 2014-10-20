using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public partial class Prospect
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int Status { get; set; } // Prospect / Member
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        // PHOTO

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual ICollection<ProspectDetail> ProspectDetails { get; set; }
        public virtual ICollection<ProspectAgentMutation> ProspectAgentMutations { get; set; }
    }
}
