using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Models.CampModels
{
    public class CampListItem
    {
        public int CampID { get; set; }

        [Display(Name = "Camp Name")]
        public string CampName { get; set; }
    }
}
