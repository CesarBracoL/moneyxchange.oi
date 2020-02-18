using System;
using System.Collections.Generic;

namespace WebAPI.MoneyXChange.Models
{
    public partial class UserAccount
    {
        public int UspId { get; set; }
        public string UsaUsername { get; set; }
        public string UsaPassword { get; set; }
        public string UsaPasswordHash { get; set; }
        public string UsaPasswordSalt { get; set; }

        public User Usp { get; set; }
    }
}
