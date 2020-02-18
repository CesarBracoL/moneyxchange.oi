using System;
using System.Collections.Generic;

namespace WebAPI.MoneyXChange.Models
{
    public partial class User
    {
        public int UspId { get; set; }
        public string UspFirstname { get; set; }
        public string UspLastname { get; set; }
        public string UspEmail { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}
