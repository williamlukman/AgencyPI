using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interface.Validation;

namespace Core.Interface.Service
{
    public interface IProspectAgentMutationService
    {
        IProspectAgentMutationValidator GetValidator();
        IQueryable<ProspectAgentMutation> GetQueryable();
        IList<ProspectAgentMutation> GetAll();
        IList<ProspectAgentMutation> GetAllByMonthCreated();
        ProspectAgentMutation GetObjectById(int Id);
        ProspectAgentMutation CreateObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        ProspectAgentMutation UpdateObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        ProspectAgentMutation SoftDeleteObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        ProspectAgentMutation ConfirmObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        ProspectAgentMutation UnconfirmObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        bool DeleteObject(int Id);
        string SetObjectCode();
    }
}