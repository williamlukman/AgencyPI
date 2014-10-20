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
        IList<Prospect> GetObjectsByFirstName(string FirstName);
        IList<Prospect> GetObjectsByLastName(string LastName);
        IList<Prospect> GetObjectsByFirstAndLastName(string FirstName, string LastName);
        Prospect CreateObject(Prospect prospect);
        Prospect UpdateObject(Prospect prospect);
        Prospect SoftDeleteObject(Prospect prospect);
        bool DeleteObject(int Id);
        bool IsNameDuplicated(Prospect prospect);
    }
}