using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Validation
{
    public interface IProspectValidator
    {
        Prospect VHasAgent(Prospect prospect, IAgentService _agentService);
        Prospect VHasNoOutstandingProspectDetail(Prospect prospect, IProspectDetailService _prospectDetailService);
        Prospect VHasNoProspectAgentMutation(Prospect prospect, IProspectAgentMutationService _prospectAgentMutationService);

        Prospect VCreateObject(Prospect prospect, IAgentService _agentService);
        Prospect VUpdateObject(Prospect prospect, IAgentService _agentService);
        Prospect VDeleteObject(Prospect prospect, IProspectService _prospectService, IProspectDetailService _prospectDetailService,
                               IProspectAgentMutationService _prospectAgentMutationService);

        bool ValidCreateObject(Prospect prospect, IAgentService _agentService);
        bool ValidUpdateObject(Prospect prospect, IAgentService _agentService);
        bool ValidDeleteObject(Prospect prospect, IProspectService _prospectService, IProspectDetailService _prospectDetailService,
                               IProspectAgentMutationService _prospectAgentMutationService);
        bool isValid(Prospect prospect);
        string PrintError(Prospect prospect);
    }
}