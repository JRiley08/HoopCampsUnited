using BBallCamp.Data;
using BBallCamp.Models.RaterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Services
{
    public class RaterServices
    {
        private readonly Guid _userID;

        public RaterServices(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateRater(RaterCreate model)
        {
            Rater rater = new Rater()
            {

                OwnerID = _userID,
                Name = model.Name,
                Age = model.Age,
                City = model.City,
                State = model.State,
                Username = GetUserName()
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Raters.Add(rater);
                return ctx.SaveChanges() == 1;
            }
        }

        public string GetUserName()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.First(c => c.Id == _userID.ToString());
                var userName = user.UserName;
                return userName;
            }
        }



        public IEnumerable<RaterListItem> GetRatersByUserID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Raters.Where(e => e.OwnerID == id).Select(e => new RaterListItem
                {
                    RaterID = e.RaterID,
                    Username = e.Username,
                    Name = e.Name,
                    Age = e.Age,
                    City = e.City,
                    State = e.State
                }).ToList();

                foreach (var rater in query)
                {
                    rater.DisplayInfo = $"{rater.Name}, {rater.Age}, {rater.City}, {rater.State}";
                }

                return query.ToArray();

            }
        }

        public RaterDetails GetRaterByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Raters.FirstOrDefault(e => e.RaterID == id);

                var model = new RaterDetails
                {
                    UserID = entity.OwnerID,
                    RaterID = entity.RaterID,
                    Name = entity.Name,
                    Age = entity.Age,
                    City = entity.City,
                    State = entity.State,
                    Username = entity.Username,
                };
                return model;
            }
        }

        public bool EditRater(RaterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Raters.FirstOrDefault(r => r.OwnerID == model.UserID);

                entity.OwnerID = model.UserID;
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.City = model.City;
                entity.State = model.State;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteRater(int raterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Raters.Single(r => r.RaterID == raterId);

                ctx.Raters.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
