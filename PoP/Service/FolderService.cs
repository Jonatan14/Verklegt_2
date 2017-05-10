using PoP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoP.Service
{
	public class FolderService
	{

		public FolderModel getFolder(int id)
		{
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				return context.Folders
					.Where(i => i.id == id)
					.FirstOrDefault();
			}
		}

		public void updateFolder(FolderModel folder)
		{
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				FolderModel dbFolder = context.Folders
					.Where(i => i.id == folder.id)
					.FirstOrDefault();

				if (dbFolder != null)
				{
					context.Entry(dbFolder).CurrentValues.SetValues(folder);
				}
				else
				{
					context.Folders.Add(folder);
				}

				context.SaveChanges();
			}
		}

		public List<FolderModel> filesInDirector(int id)
		{
			List<FolderModel> result = null;
			return result;
		}
	}
}