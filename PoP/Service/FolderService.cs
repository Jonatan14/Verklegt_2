using PoP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoP.Service
{
	public class FolderService
	{
		private FolderModel folder = null;

		public FolderModel getFolder(int id)
		{
			return folder;
		}

		public FolderModel updateFolder(FolderModel file)
		{

			return folder;
		}

		public List<FolderModel> filesInDirector(int id)
		{
			List<FolderModel> result = null;
			return result;
		}
	}
}