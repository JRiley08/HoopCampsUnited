using BBallCamp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Models.CampRatingModels
{
    public class CampRatingDetails
    {
        
        [Display(Name = "Overall Rating (Out of 10)")]
        public decimal OverallRating { get; set; }
        
        [Display(Name = "Activity Rating (Out of 10)")]
        public decimal ActivityRating { get; set; }
        
        [Display(Name = "Coaching Rating (Out of 10)")]
        public decimal CoachingRating { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Camp Name")]
        public string CampName { get; set; }

        public int RatingID { get; set; }

        public virtual Camp Camp{ get; set; }

        public virtual Rater Rater { get; set; }
    }
}
