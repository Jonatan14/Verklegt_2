using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoP.Models
{
	public class FolderModel
	{
		public int id { get; set; }
		public string name { get; set; }
		public int editedLast { get; set; } // date time!
		public int ParentFolderID { get; set; } // ID of parent folder
        public List<ApplicationDbContext> Folder;
	}
}