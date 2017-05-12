using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoP.Models
{
	public class EditorViewModel
	{
		public string Content { get; set; }
		public int projectID { get; set; }
		public int fileID { get; set; }
		public string name { get; set; }
	}
}