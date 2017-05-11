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
		private FileService _file = new FileService();
		// GET: TextEditor
		[Authorize]
		public ActionResult Index()
		{
			List<FileModel> fileList = _file.filesInProject(1);

			ViewBag.files = fileList;


			FileModel model = _file.getFile(1);
			if(model != null)
			{ 
				ViewBag.Code = model.content;
				ViewBag.DocumentID = 1;
			}
			else
			{
				ViewBag.DocumentID = 0;
			}
			return View();
		}
		public ActionResult SaveCode (EditorViewModel model)
		{
			return View("Index");
		}
	}
}