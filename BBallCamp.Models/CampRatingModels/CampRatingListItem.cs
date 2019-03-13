using BBallCamp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Models.CampRatingModels
{
    public class CampRatingListItem
    {
        public int RatingID { get; set; }
        public int CampID { get; set; }

        [Display(Name = "Overall Rating (Out of 10")]
        public decimal OverallRating { get; set; }

        public string CampDiscription { get; set; }

        public string CampName { get; set; }

        public decimal CoachingRating { get; set; }

        public decimal ActivityRating { get; set; }

        public virtual Camp Camp  { get; set; }

        public virtual Rater Rater { get; set; }
    }
}
