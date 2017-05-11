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
			if(model != null)
			{ 
				ViewBag.Code = model.content;
				ViewBag.DocumentID = model.id;
			}
			else
			{
				ViewBag.DocumentID = 0;
			}
			return View();
		}
		public ActionResult SaveCode (EditorViewModel model)
		{
            FileModel fModel = new FileModel();
            fModel.content = model.Content;
            fModel.id = 1;

            FileService service = new FileService();
            service.updateFile(fModel);

            ViewBag.code = fModel.content;
            
			return View("Index");
		}
	}
}