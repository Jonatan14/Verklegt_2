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

		internal List<FileModel> filesInProject(int id)
		{
			List<FileModel> fileList = new List<FileModel>();
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				
				List<int> IDs = context.FilesInProjectModel.Where(i => i.projectID == id).Select(i => i.fileID).ToList();

				for (int k = 0; k < IDs.Count; k++)
				{
					int n = IDs[k];
					FileModel model = context.Files
					.Where(i => i.id == n)
					.FirstOrDefault();
					fileList.Add(model);
				}
				
				return fileList;
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
        public void createFile(FileModel file, int projectID)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                context.Files.Add(file);
                int value = int.Parse(context.Files
                        .OrderByDescending(p => p.id)
                        .Select(r => r.id)
                        .First().ToString());
                value++;
                FIlesInProjectModel connection = new FIlesInProjectModel();
                connection.projectID = projectID;
                connection.fileID = value;
                context.FilesInProjectModel.Add(connection);




                context.SaveChanges();
            }
        }
	}
}