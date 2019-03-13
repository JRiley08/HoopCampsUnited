using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Data
{
    public class CampRating
    {
        [Key]
        public int RatingID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public int RaterID { get; set; }

        [Required]
        public string CampDescription { get; set; }

        [Required]
        public int CampID { get; set; }

        public string CampName { get; set; }

        public virtual Rater Rater { get; set; }
        public virtual Camp Camp { get; set; }

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
