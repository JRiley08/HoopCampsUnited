using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Models.CampRatingModels
{
    public class CampRatingCreate
    {
        [Required]
        public int CampID { get; set; }

        [Required]
        public int RaterID { get; set; }

        [Required]
        [Display(Name = "Camp Name")]
        public string CampName { get; set; }

        [Required]
        [Display(Name = "Camp Description")]
        public string CampDescription { get; set; }

        [Required]
        [Display(Name = "Overall Rating (Out of 10)")]
        public decimal OverallRating { get; set; }

        [Required]
        [Display(Name = "Activity Rating (Out of 10)")]
        public decimal ActivityRating { get; set; }
        [Required]
        [Display(Name = "Coaching Rating (Out of 10)")]
        public decimal CoachingRating { get; set; }

        public string Comments { get; set; }
    }
}
