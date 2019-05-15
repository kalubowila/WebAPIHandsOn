using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI2HandsOn.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}