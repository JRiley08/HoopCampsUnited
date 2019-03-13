using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBallCamp.Data
{
    public class Camp
    {
        [Key]
        public int CampID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string CampName { get; set; }
        [Required]
        public string CampCity { get; set; }
        [Required]
        public string CampState { get; set; }
    }
}
