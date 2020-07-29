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
            public int Id { get; set; }                         // id
            public string Character { get; set; }               // character
            public string OrigLine { get; set; }                // orig_line
            public string TranLine { get; set; }                // tran_line
            public string Proposal { get; set; }                // proposal
            public bool Comment { get; set; }                   // comment
        }

        public class File
        {
            public bool Complete { get; set; }                  // complete
            public FileContent[] Content { get; set; }          // content
        }

        public class Project
        {
            public string Name { get; set; }                    // name
            public string[] FileList { get; set; }              // file_list
            public string OrigPath { get; set; }                // orig_path
            public string TranPath { get; set; }                // tran_path
            public Dictionary<string, File> Files { get; set; } // files
        }
    }
}
