using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviser
{
    public class ProjectFile
    {
        public class FileContent
        {
            public int id { get; set; }
            public string character { get; set; }
            public string orig_line { get; set; }
            public string tran_line { get; set; }
            public string proposal { get; set; }
            public bool comment { get; set; }
        }

        public class File
        {
            public bool complete { get; set; }
            public FileContent[] content { get; set; }
        }

        public class Project
        {
            public string name { get; set; }
            public string type { get; set; }
            public string[] file_list { get; set; }
            public string orig_path { get; set; }
            public string tran_path { get; set; }
            public Dictionary<string, File> files { get; set; }
        }
    }
}
