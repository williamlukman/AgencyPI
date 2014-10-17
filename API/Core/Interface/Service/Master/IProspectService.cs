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
        Prospect GetObjectById(int Id);
        Prospect GetObjectByName(string Name);
        Prospect CreateObject(Prospect prospect);
        Prospect UpdateObject(Prospect prospect);
        Prospect SoftDeleteObject(Prospect prospect, IProspectDetailService _prospectDetailService);
        bool DeleteObject(int Id);
        bool IsNameDuplicated(Prospect prospect);
    }
}