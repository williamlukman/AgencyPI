using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DomainModel
{
    public partial class ProspectDetail
    {
        public int Id { get; set; }
        public int ProspectId { get; set; }
        public string Code { get; set; }
        public int Nature { get; set; } // Update: Appointment, Meeting, Presentation; Follow Up
        public DateTime AppointedDate { get; set; }

        public bool IsConfirmed { get; set; }
        public Nullable<DateTime> ConfirmationDate { get; set; }

        public bool IsCompleted { get; set; }
        public string Response { get; set; }
        public bool IsJoining { get; set; }
        public string Reasoning { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public virtual Prospect Prospect { get; set; }
    }
}
