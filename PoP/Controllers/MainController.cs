﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoP.Models;
using PoP.Service;
using Microsoft.AspNet.Identity;

namespace PoP.Controllers
{
	public class MainController : Controller
	{

		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Main
		public ActionResult Index()
		{
			return View();
		}
	   // [Authorize] // þegar log in virkar fyrir skil þarf að uncommenta !!!Authorize!!!
		public ActionResult Projectpage()
		{
			
			
			FolderService service = new FolderService();

			List<FolderModel> folderList = service.foldersOwnedByUser(User.Identity.GetUserId());

			ViewBag.Folders = folderList;
			return View();
		}
		// Þetta er Admin fallið herna inni sjáið þið admin pw og username
		private void CreateAdmin()
		{
			IdentityManager manager = new IdentityManager();
			if (!manager.RoleExists("Administrators"))
			{
				manager.CreateRole("Administrators");
			}
			if (!manager.UserExists("admin"))
			{
				ApplicationUser newAdmin = new ApplicationUser();
				newAdmin.UserName = "admin";
				manager.CreateUser(newAdmin, "123456");
				manager.AddUserToRole(newAdmin.Id, "Administrators");
			}
		}

// GET: Main/Details/5
public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ApplicationUser applicationUser = db.Users.Find(id);
			if (applicationUser == null)
			{
				return HttpNotFound();
			}
			return View(applicationUser);
		}

		// GET: Main/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Main/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
		{
			if (ModelState.IsValid)
			{
				db.Users.Add(applicationUser);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(applicationUser);
		}

		// GET: Main/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ApplicationUser applicationUser = db.Users.Find(id);
			if (applicationUser == null)
			{
				return HttpNotFound();
			}
			return View(applicationUser);
		}

		// POST: Main/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
		{
			if (ModelState.IsValid)
			{
				db.Entry(applicationUser).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(applicationUser);
		}

		// GET: Main/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ApplicationUser applicationUser = db.Users.Find(id);
			if (applicationUser == null)
			{
				return HttpNotFound();
			}
			return View(applicationUser);
		}

		// POST: Main/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{
			ApplicationUser applicationUser = db.Users.Find(id);
			db.Users.Remove(applicationUser);
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
	}
}
