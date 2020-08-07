﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

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

        public class RevisedFile
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
            public Dictionary<string, RevisedFile> files { get; set; }
        }

        public Project project;
        public string path;

        public void GetProject()
        {
            project = JsonConvert.DeserializeObject<Project>(File.ReadAllText(path));
        }

        public string Comment(bool comment)
        {
            if (comment)
                return "Yes";
            else
                return "No";
        }
    }
}