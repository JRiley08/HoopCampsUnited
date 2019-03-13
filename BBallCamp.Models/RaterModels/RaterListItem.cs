using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Models.RaterModels
{
    public class RaterListItem
    {
        public int RaterID { get; set; }
        [Display(Name = "Username")]
        public string Username { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Rater Information")]
        public string DisplayInfo { get; set; }
    }
}
