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
    public class ProspectAgentMutationRepository : EfRepository<ProspectAgentMutation>, IProspectAgentMutationRepository
    {
        private APIEntities entities;
        public ProspectAgentMutationRepository()
        {
            entities = new APIEntities();
        }

        public IQueryable<ProspectAgentMutation> GetQueryable()
        {
            return FindAll();
        }

        public IList<ProspectAgentMutation> GetAll()
        {
            return FindAll().ToList();
        }

        public IList<ProspectAgentMutation> GetAllByMonthCreated()
        {
            return FindAll(x => x.CreatedAt.Month == DateTime.Today.Month && !x.IsDeleted).ToList();
        }

        public IList<ProspectAgentMutation> GetObjectsByProspectId(int prospectId)
        {
            return FindAll(x => x.ProspectId == prospectId && !x.IsDeleted).ToList();
        }

        public ProspectAgentMutation GetObjectById(int Id)
        {
            ProspectAgentMutation prospectAgentMutation = Find(x => x.Id == Id && !x.IsDeleted);
            if (prospectAgentMutation != null) { prospectAgentMutation.Errors = new Dictionary<string, string>(); }
            return prospectAgentMutation;
        }

        public Agent GetAgent(ProspectAgentMutation prospectAgentMutation)
        {
            using (var db = GetContext())
            {
                Agent agent =
                    (from obj in db.Agents
                     where obj.Id == prospectAgentMutation.NewAgentId &&
                           !obj.IsDeleted
                     select obj).First();
                return agent;
            }
        }

        public Agent GetRefereeAgent(ProspectAgentMutation prospectAgentMutation)
        {
            using (var db = GetContext())
            {
                Agent referee =
                    (from obj in db.Agents
                     where obj.Id == prospectAgentMutation.RefereeAgentId &&
                           !obj.IsDeleted
                     select obj).First();
                return referee;
            }
        }

        public Agent GetDirectLeader(ProspectAgentMutation prospectAgentMutation)
        {
            using (var db = GetContext())
            {
                Agent directLeader =
                    (from obj in db.Agents
                     where obj.Id == prospectAgentMutation.NewDirectLeaderId &&
                           !obj.IsDeleted
                     select obj).First();
                return directLeader;
            }
        }

        public ProspectAgentMutation CreateObject(ProspectAgentMutation prospectAgentMutation)
        {
            prospectAgentMutation.IsConfirmed = false;
            prospectAgentMutation.IsDeleted = false;
            prospectAgentMutation.CreatedAt = DateTime.Now;
            return Create(prospectAgentMutation);
        }

        public ProspectAgentMutation UpdateObject(ProspectAgentMutation prospectAgentMutation)
        {
            prospectAgentMutation.UpdatedAt = DateTime.Now;
            Update(prospectAgentMutation);
            return prospectAgentMutation;
        }

        public ProspectAgentMutation SoftDeleteObject(ProspectAgentMutation prospectAgentMutation)
        {
            prospectAgentMutation.IsDeleted = true;
            prospectAgentMutation.DeletedAt = DateTime.Now;
            Update(prospectAgentMutation);
            return prospectAgentMutation;
        }

        public ProspectAgentMutation ConfirmObject(ProspectAgentMutation prospectAgentMutation)
        {
            prospectAgentMutation.IsConfirmed = true;
            Update(prospectAgentMutation);
            return prospectAgentMutation;
        }

        public ProspectAgentMutation UnconfirmObject(ProspectAgentMutation prospectAgentMutation)
        {
            prospectAgentMutation.IsConfirmed = false;
            prospectAgentMutation.ConfirmationDate = null;
            Update(prospectAgentMutation);
            return prospectAgentMutation;
        }

        public bool DeleteObject(int Id)
        {
            ProspectAgentMutation prospectAgentMutation =  Find(x => x.Id == Id);
            return (Delete(prospectAgentMutation) == 1) ? true : false;
        }
    }
}