using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Repository
{
    public interface IAgentRepository : IRepository<Agent>
    {
        IQueryable<Agent> GetQueryable();
        IList<Agent> GetAll();
        Agent GetObjectById(int Id);
        Agent CreateObject(Agent agent);
        Agent UpdateObject(Agent agent);
        Agent SoftDeleteObject(Agent agent);
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(Agent agent);
    }
}