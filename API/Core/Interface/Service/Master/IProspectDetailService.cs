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
        IList<ProspectDetail> GetAllByMonthCreated();
        IList<ProspectDetail> GetObjectsByProspectId(int prospectId);
        ProspectDetail GetObjectById(int Id);
        ProspectDetail CreateObject(ProspectDetail prospectDetail, IProspectService _prospectService);
        ProspectDetail UpdateObject(ProspectDetail prospectDetail, IProspectService _prospectService);
        ProspectDetail SoftDeleteObject(ProspectDetail prospectDetail);
        ProspectDetail ConfirmObject(ProspectDetail prospectDetail);
        ProspectDetail UnconfirmObject(ProspectDetail prospectDetail);
        ProspectDetail GiveFeedback(ProspectDetail prospectDetail, IProspectService _prospectService);
        bool DeleteObject(int Id);
        string SetObjectCode(string ParentCode);
    }
}