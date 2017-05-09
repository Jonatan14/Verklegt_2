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
            //ViewBag.Code = "alert('Hallo World!');";
            ViewBag.DocumentID = 1; // þarf að breita úr hardkóða í eitthvað sem nær í viðeigandi gögn í gagnagrun.

            return View();
        }
        public ActionResult SaveCode (EditorViewModel model)
        {
            return View("Index");
        }
    }
}