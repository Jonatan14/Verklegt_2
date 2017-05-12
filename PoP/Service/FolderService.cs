﻿using PoP.Models;
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


				context.SaveChanges();
			}
		}
        public void createFolder(FolderModel folder, string userID)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                context.Folders.Add(folder);
                int value = int.Parse(context.Folders
                        .OrderByDescending(p => p.id)
                        .Select(r => r.id)
                        .First().ToString());
                UsersInProjects connection = new UsersInProjects();
                connection.projectID = value;
                connection.UserID = userID;
                context.UsersInProjects.Add(connection);

                context.SaveChanges();
            }
        }

        public List<FolderModel> foldersOwnedByUser(string id)
		{
				
			List<FolderModel> folderList = new List<FolderModel>();
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				
				string UserID = id;
				List<int> IDs = context.UsersInProjects.Where(i => i.UserID == UserID).Select(i => i.projectID).ToList();

				for (int k = 0; k < IDs.Count; k++)
				{
					int n = IDs[k];
					FolderModel model = context.Folders
					.Where(i => i.id == n)
					.FirstOrDefault();
					folderList.Add(model);
				}
				return folderList;
			}
		}

        internal string updateFolder(List<FolderModel> folderList)
        {
            throw new NotImplementedException();
        }
    }
}