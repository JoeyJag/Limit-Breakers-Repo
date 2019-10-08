using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Limit_Breakers_Repo.Models;

namespace Limit_Breakers_Repo.Controllers
{
    public class ReviewGameViewModelController : Controller
    {
        // GET: ReviewGameViewModel
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            int c = 0;
            List<ReviewGameViewModel> vm = new List<ReviewGameViewModel>();
            var list = (from x in db.GameDetails
                        join a in db.Review on x.GameID equals a.GameID
                        select new
                        {
                            x.Name,
                            a.ReviewOfGame,
                            a.Rating
                          
                        }).ToList();
            foreach (var x in list)
            {
                ReviewGameViewModel obj = new ReviewGameViewModel();
                obj.Name = x.Name;
                obj.ReviewOfGame = x.ReviewOfGame;
                obj.Rating = x.Rating;
                vm.Add(obj);
            }
            return View(vm);

        }
 
    }
}