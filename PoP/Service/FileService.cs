using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoP.Models;

namespace PoP.Service
{
    public class FileService  
    {
        private FileModel file = null;

        public FileModel getFile(int id)
        {

            return file;
        }

        public FileModel updateFile(FileModel file)
        {
            return file;
        }

        public int getFileVersion(FileModel model)
        {
            int version = 0;
            return version;
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