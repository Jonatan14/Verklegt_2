using PoP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoP.Controllers
{
    public class TextEditorController : Controller
    {
        // GET: TextEditor
        public ActionResult Index()
        {
            ViewBag.Code = "alert('Hallo World!');";
            return View();
        }
        public ActionResult SaveCode (EditorViewModel model)
        {
            return View("Index");
        }
    }
}