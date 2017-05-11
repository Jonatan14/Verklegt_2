using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoP.Models
{
	public class UsersInProjects
	{
		public int id { get; set; }
		public string UserID { get; set; }
		public int projectID { get; set; }	
	}
}