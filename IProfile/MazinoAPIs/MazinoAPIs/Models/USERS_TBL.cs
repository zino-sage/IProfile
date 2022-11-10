using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MazinoAPIs.Models
{
    public class USERS_TBL
    {
        [Key]
        public int USERID { get; set; }
        public int ACCOUNTID { get; set; }
        [Required]
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        [Required]
        public string EMAIL { get; set; }
        public bool DELETED { get; internal set; }
    }
}
