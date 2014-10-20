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
    public class ProspectRepository : EfRepository<Prospect>, IProspectRepository
    {
        private APIEntities entities;
        public ProspectRepository()
        {
            entities = new APIEntities();
        }

        public IQueryable<Prospect> GetQueryable()
        {
            return FindAll();
        }

        public IList<Prospect> GetAll()
        {
            return FindAll().ToList();
        }

        public IList<Prospect> GetObjectsByAgentId(int AgentId)
        {
            return FindAll(x => x.AgentId == AgentId && !x.IsDeleted).ToList();
        }

        public Prospect GetObjectById(int Id)
        {
            Prospect prospect = Find(x => x.Id == Id && !x.IsDeleted);
            if (prospect != null) { prospect.Errors = new Dictionary<string, string>(); }
            return prospect;
        }

        public IList<Prospect> GetObjectsByFirstName(string FirstName)
        {
            return FindAll(x => x.FirstName == FirstName && !x.IsDeleted).ToList();
        }

        public IList<Prospect> GetObjectsByLastName(string LastName)
        {
            return FindAll(x => x.LastName == LastName && !x.IsDeleted).ToList();
        }

        public IList<Prospect> GetObjectsByFirstAndLastName(string FirstName, string LastName)
        {
            return FindAll(x => x.FirstName == FirstName && x.LastName == LastName && !x.IsDeleted).ToList();
        }

        public Prospect CreateObject(Prospect prospect)
        {
            prospect.IsDeleted = false;
            prospect.CreatedAt = DateTime.Now;
            return Create(prospect);
        }

        public Prospect UpdateObject(Prospect prospect)
        {
            prospect.UpdatedAt = DateTime.Now;
            Update(prospect);
            return prospect;
        }

        public Prospect SoftDeleteObject(Prospect prospect)
        {
            prospect.IsDeleted = true;
            prospect.DeletedAt = DateTime.Now;
            Update(prospect);
            return prospect;
        }

        public bool DeleteObject(int Id)
        {
            Prospect prospect =  Find(x => x.Id == Id);
            return (Delete(prospect) == 1) ? true : false;
        }

        public bool IsNameDuplicated(Prospect prospect)
        {
            IQueryable<Prospect> prospects = FindAll(x => x.FirstName == prospect.FirstName && x.LastName == prospect.LastName &&
                                                          !x.IsDeleted && x.Id != prospect.Id);
            return (prospects.Count() > 0 ? true : false);
        }

    }
}