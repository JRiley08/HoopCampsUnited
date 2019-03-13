using BBallCamp.Data;
using BBallCamp.Models.CampModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Services
{
    public class CampServices
    {
        private readonly Guid _userID;

        public CampServices(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateCamp(CampCreate model)
        {
            Camp basketballcamp = new Camp()
            {
                OwnerID = _userID,
                CampName = model.CampName,
                CampCity = model.CampCity,
                CampState = model.CampState
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Camps.Add(basketballcamp);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CampListItem> GetCampsByUserID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Camps.Where(c => c.OwnerID == id).Select(c => new CampListItem
                {
                    CampID = c.CampID,
                    CampName = c.CampName
                });

                return query.ToArray();
            }
        }

        public CampDetails GetCampByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Camps.FirstOrDefault(c => c.CampID == id);
                var model = new CampDetails
                {
                    CampID = entity.CampID,
                    CampName = entity.CampName,
                    CampCity = entity.CampCity,
                    CampState = entity.CampState
                };
                return model;
            }
        }

        public bool EditCamp(CampEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Camps.FirstOrDefault(c => c.CampID == model.CampID);

                entity.CampName = model.CampName;
                entity.CampCity = model.CampCity;
                entity.CampState = model.CampState;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteCamp(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Camps.Single(c => c.CampID == id);

                ctx.Camps.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
