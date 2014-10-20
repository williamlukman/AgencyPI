using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Validation
{
    public interface IProspectAgentMutationValidator
    {
        ProspectAgentMutation VHasProspect(ProspectAgentMutation ProspectAgentMutation, IProspectService _prospectService);
        ProspectAgentMutation VHasNewAgent(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService);
        ProspectAgentMutation VHasRefereeAgent(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService);
        ProspectAgentMutation VHasDirectLeader(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService);
        ProspectAgentMutation VHasRegistrationDate(ProspectAgentMutation ProspectAgentMutation);
        ProspectAgentMutation VHasNotBeenConfirmed(ProspectAgentMutation ProspectAgentMutation);
        ProspectAgentMutation VHasBeenConfirmed(ProspectAgentMutation ProspectAgentMutation);

        ProspectAgentMutation VCreateObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        ProspectAgentMutation VUpdateObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        ProspectAgentMutation VDeleteObject(ProspectAgentMutation prospectAgentMutation);
        ProspectAgentMutation VConfirmObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        ProspectAgentMutation VUnconfirmObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        
        bool ValidCreateObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        bool ValidUpdateObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        bool ValidDeleteObject(ProspectAgentMutation prospectAgentMutation);
        bool ValidConfirmObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);
        bool ValidUnconfirmObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService);

        bool isValid(ProspectAgentMutation prospectAgentMutation);
        string PrintError(ProspectAgentMutation prospectAgentMutation);
    }
}