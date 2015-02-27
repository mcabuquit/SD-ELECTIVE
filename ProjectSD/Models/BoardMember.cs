using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSD.Models
{
    public class BoardMember
    {
        public int BoardMemberID { set; get; }
        public String DateAdded { set; get; }
        public virtual Users Users { set; get; }
        public virtual Board Board { set; get; }
    }
}