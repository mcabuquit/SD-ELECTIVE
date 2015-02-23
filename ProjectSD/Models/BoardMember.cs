using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSD.Models
{
    public class BoardMember
    {
        public int BoardID { set; get; }
        public int UserID { set; get; }
        public String DateAdded { set; get; }
    }
}