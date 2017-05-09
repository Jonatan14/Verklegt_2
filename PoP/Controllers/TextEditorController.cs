using PoP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoP.Service;

namespace PoP.Controllers
{
	public class TextEditorController : Controller
	{
		// GET: TextEditor
		public ActionResult Index()
		{

			
			FileService _file = new FileService();
			FileModel model = _file.getFile(1);
			ViewBag.Code = model.content;
			ViewBag.DocumentID = 1;
			return View();
		}
		public ActionResult SaveCode (EditorViewModel model)
		{
			return View("Index");
		}
	}
}