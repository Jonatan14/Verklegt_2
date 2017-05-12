using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoP.Models;
using PoP.Service;
using System.IO;
using Microsoft.AspNet.Identity;

namespace PoP.Controllers
{
	public class MainController : Controller
	{

		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Main
		public ActionResult Index()
		{
			if((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Projectpage", "Main");
			}
			return View();
		}
		[Authorize] // þegar log in virkar fyrir skil þarf að uncommenta !!!Authorize!!!
		public ActionResult Projectpage()
		{
			
			
			FolderService service = new FolderService();

			List<FolderModel> folderList = service.foldersOwnedByUser(User.Identity.GetUserId());
			if (folderList != null)
			{
				ViewBag.Folders = folderList;
			}
			else { ViewBag.Folders = null; }
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
	/*	public ActionResult Create()
		{
			return View();
		}*/

		// POST: Main/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		public ActionResult Create()
		{
			FolderService service = new FolderService();
			List<FolderModel> folderList = service.foldersOwnedByUser(User.Identity.GetUserId());
			Directory.CreateDirectory(service.updateFolder(folderList));

			return View();
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
		private FileService _file = new FileService();
		// GET: TextEditor
		[Authorize]
		public ActionResult TextEdit(int id)
		{
			ViewBag.ProjectID = id;
			List<FileModel> fileList = _file.filesInProject(id);

			ViewBag.files = fileList;


			FileModel model = fileList[0];
			if (model != null)
			{
				ViewBag.Code = model.content;
				ViewBag.DocumentID = model.id;
				ViewBag.Name = model.name;
			}
			else
			{
				ViewBag.DocumentID = 0;
			}
			return View();
		}

		public ActionResult OpenFile(int id, int modelID)
		{
            //Svissar á milli file-a innan projects.
            List<FileModel> fileList = _file.filesInProject(id);
            ViewBag.files = fileList;


			FileModel model = _file.getFile(modelID);
			ViewBag.Name = model.name;
			ViewBag.ProjectID = id;
			ViewBag.Code = model.content;
			ViewBag.DocumentID = model.id;
			return View();
		}
		public ActionResult SaveCode(EditorViewModel model)
		{
			FileModel fModel = new FileModel();
			fModel.id = model.fileID;
			fModel.name = model.name;
			fModel.content = model.Content;

			_file.updateFile(fModel);
			return View();
		}
        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(FolderModel model)
        {
            if (ModelState.IsValid)
            {
                FolderModel newFolder = new FolderModel();
                newFolder.name = model.name;

                FolderService sfolder = new FolderService();
                sfolder.createFolder(newFolder, User.Identity.GetUserId());

                return RedirectToAction("Index");
            }

            return View(model);
        }
		
        public ActionResult MakeFile(int projectID)
        {
			
            return View(ViewBag.projectID);
        }

        [HttpPost]
        public ActionResult MakeFile(FileModel model)
        {
            if (ModelState.IsValid)
            {
                FileModel newFile = new FileModel();
                newFile.name = model.name;

                
               // _file.createFile(newFile, projectID);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }

}
