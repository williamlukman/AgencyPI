using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interface.Validation;

namespace Core.Interface.Service
{
    public interface IProspectService
    {
        IProspectValidator GetValidator();
        IQueryable<Prospect> GetQueryable();
        IList<Prospect> GetAll();
        IList<Prospect> GetObjectsByAgentId(int agentId);
        IList<Prospect> GetObjectsByFirstName(string FirstName);
        IList<Prospect> GetObjectsByLastName(string LastName);
        IList<Prospect> GetObjectsByFirstAndLastName(string FirstName, string LastName);
        Prospect GetObjectById(int Id);
        Prospect CreateObject(Prospect prospect, IAgentService _agentService);
        Prospect UpdateObject(Prospect prospect, IAgentService _agentService);
        Prospect SoftDeleteObject(Prospect prospect, IProspectDetailService _prospectDetailService, IProspectAgentMutationService _prospectAgentMutationService);
        bool DeleteObject(int Id);
        bool IsNameDuplicated(Prospect prospect);
    }
}