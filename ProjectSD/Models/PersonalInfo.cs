using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSD.Models
{
    public class PersonalInfo
    {
        public int PersonalInfoID { set; get; }
        public String Name { set; get; }
        public int UserID { set; get; }

        public virtual Users Users { set; get; }
    }
}