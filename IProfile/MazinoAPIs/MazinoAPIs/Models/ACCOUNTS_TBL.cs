using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MazinoAPIs.Models
{
    public class ACCOUNTS_TBL
    {
        [Key]
        public int ACCOUNTID { get; set; }
        [Required]
        public string COMPANYNAME { get; set; }
        public string WEBSITE { get; set; }
        public bool DELETED { get; set; }
    }
}
