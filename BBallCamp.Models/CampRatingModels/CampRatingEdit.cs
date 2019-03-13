using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Models.CampRatingModels
{
    public class CampRatingEdit
    {
        public int RatingID { get; set; }

        public int CampID { get; set; }

        public string CampName { get; set; }

        public string CampDescription { get; set; }

        public decimal OverallRating { get; set; }

        public decimal ActivityRating { get; set; }

        public decimal CoachingRating { get; set; }
    }
}
