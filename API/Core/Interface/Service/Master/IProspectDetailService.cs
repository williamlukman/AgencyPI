using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interface.Validation;

namespace Core.Interface.Service
{
    public interface IProspectDetailService
    {
        IProspectDetailValidator GetValidator();
        IQueryable<ProspectDetail> GetQueryable();
        IList<ProspectDetail> GetAll();
        IList<ProspectDetail> GetObjectsByProspectId(int prospectId);
        ProspectDetail GetObjectById(int Id);
        ProspectDetail CreateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        ProspectDetail UpdateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        ProspectDetail SoftDeleteObject(ProspectDetail prospectDetail);
        ProspectDetail ConfirmObject(ProspectDetail prospectDetail, DateTime ConfirmationDate, IAgentService _agentService, IProspectService _prospectService);
        ProspectDetail UnconfirmObject(ProspectDetail prospectDetail);
        ProspectDetail GiveFeedback(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService);
        bool DeleteObject(int Id);
    }
}