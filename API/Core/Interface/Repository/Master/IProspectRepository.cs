using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Repository
{
    public interface IProspectRepository : IRepository<Prospect>
    {
        IQueryable<Prospect> GetQueryable();
        IList<Prospect> GetAll();
        IList<Prospect> GetObjectsByAgentId(int agentId);
        Prospect GetObjectById(int Id);
        Prospect GetObjectByName(string Name);
        Prospect CreateObject(Prospect prospect);
        Prospect UpdateObject(Prospect prospect);
        Prospect SoftDeleteObject(Prospect prospect);
        bool DeleteObject(int Id);
        bool IsNameDuplicated(Prospect prospect);
    }
}