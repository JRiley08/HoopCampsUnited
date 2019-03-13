using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Models.CampModels
{
    public class CampCreate
    {
        [Required]
        [Display(Name = "Camp Name")]
        public string CampName { get; set; }

        [Required]
        [Display(Name = "Camp City")]
        public string CampCity { get; set; }

        [Required]
        [Display(Name = "Camp State")]
        public string CampState { get; set; }
    }
}
