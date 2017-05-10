using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoP.Models;
using System.Web.Mvc;

namespace PoP.Service
{
	public class FileService
	{
		

		
		public FileModel getFile(int id)
		{

			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				return context.Files
					.Where(i => i.id == id)
					.FirstOrDefault();
			}
		}

		public void updateFile(FileModel file)
		{
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				FileModel dbFile = context.Files
					.Where(i => i.id == file.id)
					.FirstOrDefault();

				if (dbFile != null)
				{
					context.Entry(dbFile).CurrentValues.SetValues(file);
				}
				else
				{
					context.Files.Add(file);
				}

				context.SaveChanges();
			}
		}


		public bool isNewest(FileModel model)
		{
			return true;
		}

		public int activeEditorsCount(FileModel model)
		{
			int count = 0;
			return count;
		}

		public List<AccountModel>activeEditors()
		{
			List<AccountModel> modelList = null;
			return modelList;
		}
	}
}