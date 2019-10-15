﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Limit_Breakers_Repo.Models;

namespace Limit_Breakers_Repo.Controllers
{
    public class GameDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameDetails
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Genre")
            {
                return View(db.GameDetails.Where(x => x.Genre == search || search == null).ToList());
            }
            else
            {
                return View(db.GameDetails.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }
        }

        // GET: GameDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameDetails gameDetails = db.GameDetails.Find(id);
            if (gameDetails == null)
            {
                return HttpNotFound();
            }
            return View(gameDetails);
        }

        // GET: GameDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameID,Name,Genre,Description")] GameDetails gameDetails, HttpPostedFileBase UploadGame, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                if (UploadGame != null)
                {
                    UploadGame.SaveAs(Server.MapPath("/") + "/Content/" + UploadGame.FileName);
                    gameDetails.GameLocation = UploadGame.FileName;
                }
                else
                {
                    return View();
                }
                if (UploadImage != null)
                {
                    UploadImage.SaveAs(Server.MapPath("/") + "/Content/" + UploadImage.FileName);
                    gameDetails.ImageLocation = UploadImage.FileName;
                }
                else
                {
                    return View();
                }

                db.GameDetails.Add(gameDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameDetails);
        }

        // GET: GameDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameDetails gameDetails = db.GameDetails.Find(id);
            if (gameDetails == null)
            {
                return HttpNotFound();
            }
            return View(gameDetails);
        }

        // POST: GameDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameID,Name,Genre,Description,ImageLocation,GameLocation")] GameDetails gameDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameDetails);
        }

        // GET: GameDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameDetails gameDetails = db.GameDetails.Find(id);
            if (gameDetails == null)
            {
                return HttpNotFound();
            }
            return View(gameDetails);
        }

        public ActionResult GamesPage( string searchBy, string search)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (searchBy == "Genre")
            {
                return View(db.GameDetails.Where(x => x.Genre == search || search == null).ToList());
            }
            else
            {
                return View(db.GameDetails.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }
            
        }


        // POST: GameDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameDetails gameDetails = db.GameDetails.Find(id);
            db.GameDetails.Remove(gameDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AdminView()
        {
            return View();
        }
    }
}