using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazinoAPIs.DTOs
{
    public class UserDTO
    {
        public int userId { get; set; }
        public string email { get;  set; }
        public string companyName { get;  set; }
        public string firstName { get; set; }
        public string lastName { get;  set; }
        public int accountId { get; set; }
    }
}
