using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoP.Models
{
    public class FileModel
    {
        public int id { get; set; }
        public string content { get; set; }
        public string name { get; set; }
        public int version { get; set; }
        public int ParentFolderID { get; set; }
        public List<ApplicationDbContext> File;
    }
}