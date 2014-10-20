using Core.DomainModel;
using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Context;
using Data.Repository;
using System.Data;

namespace Data.Repository
{
    public class ItemRepository : EfRepository<Agent>, IAgentRepository
    {
        private APIEntities entities;
        public ItemRepository()
        {
            entities = new APIEntities();
        }

        public IQueryable<Agent> GetQueryable()
        {
            return FindAll();
        }

        public IList<Agent> GetAll()
        {
            return FindAll().ToList();
        }

        public IList<Agent> GetObjectsByDirectLeaderId(int DirectLeaderId)
        {
            return FindAll(x => x.DirectLeaderId == DirectLeaderId && !x.IsDeleted).ToList();
        }

        public Agent GetObjectById(int Id)
        {
            Agent agent = Find(x => x.Id == Id && !x.IsDeleted);
            if (agent != null) { agent.Errors = new Dictionary<string, string>(); }
            return agent;
        }

        public Agent CreateObject(Agent agent)
        {
            agent.IsDeleted = false;
            agent.CreatedAt = DateTime.Now;
            return Create(agent);
        }

        public Agent UpdateObject(Agent agent)
        {
            agent.UpdatedAt = DateTime.Now;
            Update(agent);
            return agent;
        }

        public Agent SoftDeleteObject(Agent agent)
        {
            agent.IsDeleted = true;
            agent.DeletedAt = DateTime.Now;
            Update(agent);
            return agent;
        }

        public bool DeleteObject(int Id)
        {
            Agent agent = Find(x => x.Id == Id);
            return (Delete(agent) == 1) ? true : false;
        }

        public bool IsCodeDuplicated(Agent agent)
        {
            IQueryable<Agent> items = FindAll(x => x.Code == agent.Code && !x.IsDeleted && x.Id != agent.Id);
            return (items.Count() > 0 ? true : false);
        }
    }
}