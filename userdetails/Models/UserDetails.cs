using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userdetails.Models
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Education { get; set; }
        public string Location { get; set; }
        public List<UserDetails> usersinfo { get; set; }
    }
}
