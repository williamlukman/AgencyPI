using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Validation
{
    public interface IProspectDetailValidator
    {
        ProspectDetail VHasProspect(ProspectDetail prospectDetail, IProspectService _prospectService);
        ProspectDetail VHasNature(ProspectDetail prospectDetail);
        ProspectDetail VAgentHasPermissionForDetailNature(ProspectDetail prospectDetail, IProspectService _prospectService, IAgentService _agentService);
        ProspectDetail VHasAppointedDate(ProspectDetail prospectDetail);
        ProspectDetail VHasBeenConfirmed(ProspectDetail prospectDetail);
        ProspectDetail VHasNotBeenConfirmed(ProspectDetail prospectDetail);
        ProspectDetail VHasBeenCompleted(ProspectDetail prospectDetail);
        ProspectDetail VHasNotBeenCompleted(ProspectDetail prospectDetail);
        ProspectDetail VHasResponse(ProspectDetail prospectDetail);

        ProspectDetail VCreateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        ProspectDetail VUpdateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        ProspectDetail VDeleteObject(ProspectDetail prospectDetail);
        ProspectDetail VConfirmObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        ProspectDetail VUnconfirmObject(ProspectDetail prospectDetail);
        ProspectDetail VGiveFeedback(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        
        bool ValidCreateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        bool ValidUpdateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        bool ValidDeleteObject(ProspectDetail prospectDetail);
        bool ValidConfirmObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        bool ValidUnconfirmObject(ProspectDetail prospectDetail);
        bool ValidGiveFeedback(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        bool isValid(ProspectDetail prospectDetail);
        string PrintError(ProspectDetail prospectDetail);
    }
}