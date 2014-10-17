using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Repository
{
    public interface IProspectDetailRepository : IRepository<ProspectDetail>
    {
        IQueryable<ProspectDetail> GetQueryable();
        IList<ProspectDetail> GetAll();
        IList<ProspectDetail> GetAllByMonthCreated();
        IList<ProspectDetail> GetObjectsByProspectId(int prospectId);
        ProspectDetail GetObjectById(int Id);
        ProspectDetail CreateObject(ProspectDetail prospectDetail);
        ProspectDetail UpdateObject(ProspectDetail prospectDetail);
        ProspectDetail SoftDeleteObject(ProspectDetail prospectDetail);
        ProspectDetail ConfirmObject(ProspectDetail prospectDetail);
        ProspectDetail UnconfirmObject(ProspectDetail prospectDetail);
        bool DeleteObject(int Id);
        string SetObjectCode(string ParentCode);
    }
}