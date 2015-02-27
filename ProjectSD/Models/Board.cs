using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSD.Models
{
    public class Board
    {
        public int BoardID {internal set; get; }
        public String BoardName {set; get;}
        public DateTime BoardCreated { set; get; }
        
    }
}