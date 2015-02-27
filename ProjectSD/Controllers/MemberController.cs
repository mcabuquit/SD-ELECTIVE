using ProjectSD.DAL;
using ProjectSD.Models;
using ProjectSD.MySession;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSD.Controllers
{
    public class MemberController : Controller
    {
        MyDatabaseContext db = new MyDatabaseContext();
        //
        // GET: /Member/

        public ActionResult Index()
        {
            var bm = db.BoardMember.Where(b=>b.Users==MyOwnSession.getInstance().user);
            var list = new List<Board>();


            
            return View(list);
        }


        //
        //POST:/Member/AddBoard
        [HttpPost]
        public ActionResult AddBoard(Board board)
        {
           
          try {
            if (ModelState.IsValid){

                db.Board.Add(board);
                db.SaveChanges();
                BoardMember bm = new BoardMember()
                {
                    Users=MyOwnSession.getInstance().user,
                    Board=board
                };
                db.BoardMember.Add(bm);
                db.SaveChanges();
                
            }
          }catch(DataException){
          }
           
            return View();
        }
    }
}
