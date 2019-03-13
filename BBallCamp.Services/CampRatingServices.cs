using BBallCamp.Data;
using BBallCamp.Models.CampRatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Services
{
    public class CampRatingServices
    {
        private readonly Guid _userId;
        public CampRatingServices(Guid userId)
        {
            _userId = userId;
        }
        public CampRatingServices() { }

        public bool CreateRating(CampRatingCreate model)
        {
            var rating = new CampRating
            {
                OwnerID = _userId,
                CampID = model.CampID,
                RaterID = model.RaterID,
                CampName = model.CampName,
                CampDescription = model.CampDescription,
                OverallRating = model.OverallRating,
                ActivityRating = model.ActivityRating,
                CoachingRating = model.CoachingRating,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CampRatings.Add(rating);
                return ctx.SaveChanges() == 1;
            }
            
        }

        public IEnumerable<CampRatingListItem> GetRatingsByUserID(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CampRatings.Where(c => c.OwnerID == userId).Select(c => new CampRatingListItem
                {
                    CampID = c.CampID,
                    RatingID = c.RatingID,
                    CampName= c.CampName,
                    OverallRating = c.OverallRating,
                    ActivityRating = c.ActivityRating,
                    CoachingRating = c.CoachingRating,

                });

                return query.ToArray();
            }
        }

        public IEnumerable<CampRatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CampRatings.Select(r => new CampRatingListItem
                {
                    CampID = r.CampID,
                    RatingID = r.RatingID,
                    CampName = r.CampName,
                    OverallRating = r.OverallRating,
                    ActivityRating = r.ActivityRating,
                    CoachingRating = r.CoachingRating,
                });

                return query.ToArray();
            }
        }

        public CampRatingDetails GetRatingsByRatingID(int ratingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CampRatings.FirstOrDefault(r => r.RatingID == ratingId);
                var model = new CampRatingDetails()
                {
                    RatingID = entity.RatingID,
                    Username = entity.Rater.Username,
                    CampName = entity.Camp.CampName,
                    OverallRating = entity.OverallRating,
                    ActivityRating = entity.ActivityRating,
                    CoachingRating = entity.CoachingRating,

                };
                return model;

                
            }
        }

        public bool EditCampRating(CampRatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CampRatings.Single(r => r.RatingID == model.RatingID);

                
                entity.CampName = model.CampName;
                entity.CampDescription = model.CampDescription;
                entity.OverallRating = model.OverallRating;
                entity.ActivityRating = model.ActivityRating;
                entity.CoachingRating = model.CoachingRating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CampRatings.Single(r => r.RatingID == id);

                ctx.CampRatings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
